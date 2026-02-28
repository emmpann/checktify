using Checktify.Entity.Identity.Entities;
using Checktify.Entity.Identity.ViewModels;
using Checktify.Repository.Context;
using Checktify.Service.Helpers.Identity.EmailHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Checktify.Service.Extensions.Identity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection LoadIdentityExtensions(this IServiceCollection services, IConfiguration config)
        {

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequiredLength = 6; ;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequiredUniqueChars = 1;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                var newCookie = new CookieBuilder();
                newCookie.Name = "ChecktifyCookie";

                opt.LoginPath = new PathString("/Authentication/Login");
                opt.LogoutPath = new PathString("/Authentication/Logout");
                opt.AccessDeniedPath = new PathString("/Authentication/AccessDenied");
                opt.Cookie = newCookie;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });

            services.Configure<DataProtectionTokenProviderOptions>( opt =>
            {
                opt.TokenLifespan = TimeSpan.FromMinutes(15);
            });

            services.AddScoped<IEmailSendMethod, EmailSendMethod>();

            services.Configure<GmailInformationsVM>(config.GetSection("EmailSettings"));

            return services;
        }
    }
}
