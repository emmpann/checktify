using Checktify.Service.Extensions.Identity;
using Checktify.Service.FluentValidation.WebApplication.CompanyValidation;
using Checktify.Service.Helpers.Generic.Image;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Checktify.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.LoadIdentityExtensions(config);

            services.AddAutoMapper(cfg => { }, Assembly.GetExecutingAssembly());

            var serviceTypes = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service"));
            foreach (var serviceType in serviceTypes)
            {
                var iServiceType = serviceType.GetInterface($"I{serviceType.Name}");

                if (iServiceType != null)
                {
                    services.AddScoped(iServiceType, serviceType);
                }
            }

            services.AddFluentValidationAutoValidation(cfg =>
            {
                cfg.DisableDataAnnotationsValidation = true;
            });

            services.AddValidatorsFromAssemblyContaining<CompanyAddValidation>();

            services.AddScoped<IImageHelper, ImageHelper>();
            return services;
        }
    }
}
