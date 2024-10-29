using Candidato.Core.Application.Interfaces;
using Candidato.Core.Application.Interfaces.Repositories;
using Candidato.Core.Application.Interfaces.Services;
using Candidato.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Candidato.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection service)
        {
            service.AddAutoMapper(Assembly.GetExecutingAssembly());


            service.AddTransient<ICandidatoService, CandidatoService>();
            service.AddTransient<IApiRequestLogService, ApiRequestLogService>();
        }
    }
}
