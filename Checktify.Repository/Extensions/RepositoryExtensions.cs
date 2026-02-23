using Checktify.Repository.Context;
using Checktify.Repository.Repositories.Abstract;
using Checktify.Repository.Repositories.Concrete;
using Checktify.Repository.UnitOfWorks.Abstract;
using Checktify.Repository.UnitOfWorks.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checktify.Repository.Extensions
{
    public static class RepositoryExtensions
    {
        public static IServiceCollection LoadRepositoryExtenstions(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
