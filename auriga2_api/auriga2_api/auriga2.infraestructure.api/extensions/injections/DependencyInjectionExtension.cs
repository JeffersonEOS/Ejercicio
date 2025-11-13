using auriga2.infraestructure.application;
using auriga2.infraestructure.data.repositories;
using auriga2.domain.repositories;


namespace auriga2.infraestructure.api.extensions.injections
{
    public class DependencyInjectionExtension
    {
        //clases parciales 
        //libreria de automaper
        //
        public static void ConfigureDependenciesInjectionsServices(WebApplicationBuilder builder, IConfiguration configuration)
        {
            builder.Services.AddScoped<IApplicationService, ApplicationService>();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IUserRoleDomainRepository, UserRoleRepository>();
            builder.Services.AddScoped<ICatalogDomainRepository, CatalogRepository>();
            builder.Services.AddScoped<IConfigDomainRepository, ConfigRepository>();
            builder.Services.AddScoped<IEmailTemplateDomainRepository, EmailTemplateRepository>();
            builder.Services.AddScoped<IRoleDomainRepository, RoleRepository>();
            builder.Services.AddScoped<IUserDomainRepository, UserRepository>();
            builder.Services.AddScoped<IProjectDomainRepository, ProjectRepository>();
            builder.Services.AddScoped<IUserInterestDomainRepository, UserInterestRepository>();

        }
    }
}
