using auriga2.domain.models;
using auriga2.infraestructure.api.extensions.automappers;
using auriga2.infraestructure.api.extensions.injections;
using auriga2.infraestructure.api.extensions.migrations;
using auriga2.infraestructure.api.extensions.securities;
using auriga2.infraestructure.api.extensions.servers;
using auriga2.infraestructure.api.middlewares;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Autofac
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(b =>
{
    b.Register(context =>
    {
        ClaimsPrincipal? identityUser = context.Resolve<IHttpContextAccessor>()?.HttpContext?.User;

        Claim? data = ((ClaimsIdentity)identityUser?.Identity!)?
                      .Claims.FirstOrDefault(x => x.Type == "id");

        UserInfoModel userInfo = identityUser != null && data != null
            ? new UserInfoModel()
            {
                Id = identityUser.Identity != null && identityUser.Identity.IsAuthenticated
                    ? Convert.ToInt32(((ClaimsIdentity)identityUser.Identity)
                    .Claims.FirstOrDefault(x => x.Type == "id")?.Value)
                    : 0,
                UserName = identityUser.Identity != null && identityUser.Identity.IsAuthenticated
                    ? ((ClaimsIdentity)identityUser.Identity)
                    .Claims.FirstOrDefault(x => x.Type == "username")?.Value
                    : String.Empty,
            }
            : new UserInfoModel() { Id = 0, UserName = "" };

        return userInfo;
    })
    .AsSelf()
    .InstancePerLifetimeScope();
});

// Controllers + JSON
builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// CORS
builder.Services.AddCors(p => p.AddPolicy("corsDev", configure =>
{
    configure.WithOrigins("*").AllowAnyHeader().AllowAnyMethod();
}));

// Configuración de environment
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

IConfiguration configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
    .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: false)
    .Build();

// AutoMapper
AutoMapperExtension.ConfigureAutoMappersServices(builder.Services);

// Inyección de dependencias
DependencyInjectionExtension.ConfigureDependenciesInjectionsServices(builder, configuration);

// SQL
SqlExtension.ConfigureSQLServices(builder);

// JWT
JwtExtension.ConfigureSecurityServices(builder);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ───────────── MIDDLEWARE ORDER CORRECTO ─────────────

// Swagger solo en dev
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// HTTPS
app.UseHttpsRedirection();

// CORS debe ir antes de autenticación
if (app.Environment.IsDevelopment())
{
    app.UseCors("corsDev");
}

// JwtMiddleware personalizado (antes que authentication/authorization)
app.UseMiddleware<JwtMiddleware>();

// Seguridad estándar
app.UseAuthentication();   // <-- NECESARIO ANTES DE Authorization
app.UseAuthorization();

// Controladores
app.MapControllers();

// Migraciones
app.MigrateDatabase();

// Middleware de excepciones al final
app.UseMiddleware<ErrorHandlerMiddleware>();

// Run
app.Run();
