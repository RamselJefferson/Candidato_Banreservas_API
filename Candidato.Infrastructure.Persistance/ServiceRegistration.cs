using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System;
using Candidato.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Candidato.Core.Application.Interfaces.Repositories;
using Candidato.Infrastructure.Persistance.Repository;

namespace Candidato.Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceInfrastructure(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(config.GetConnectionString("DefaultConnection"),
                    m => m.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            svc.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
