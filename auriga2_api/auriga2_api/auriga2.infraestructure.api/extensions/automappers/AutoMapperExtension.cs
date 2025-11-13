using System.Reflection;
using auriga2.infraestructure.application.profiles;

namespace auriga2.infraestructure.api.extensions.automappers
{
    public static class AutoMapperExtension
    {
        public static void ConfigureAutoMappersServices(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(BaseProfile).GetTypeInfo().Assembly);
        }
    }
}
