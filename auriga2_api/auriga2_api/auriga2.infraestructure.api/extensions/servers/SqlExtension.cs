using auriga2.infraestructure.data.contexts;
using Microsoft.EntityFrameworkCore;

namespace auriga2.infraestructure.api.extensions.servers
{
    public class SqlExtension
    {
        public static void ConfigureSQLServices(WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<Auriga2Context>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Auriga2Connection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly("auriga2.infraestructure.data");
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(90), errorNumbersToAdd: null);
                    });
                }, ServiceLifetime.Transient);
        }
    }
}
