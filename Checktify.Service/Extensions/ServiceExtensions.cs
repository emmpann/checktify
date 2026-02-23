using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Checktify.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services)
        {
            // Provide an explicit configuration Action so the overload that accepts assemblies is used.
            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
