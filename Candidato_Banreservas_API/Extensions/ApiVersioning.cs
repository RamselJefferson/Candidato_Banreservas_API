using Microsoft.AspNetCore.Mvc;

namespace Candidato_Banreservas_API.Extensions
{
    public static class ApiVersioning
    {
        public static void AddApiVersioningExtension(this IServiceCollection svc)
        {
            svc.AddApiVersioning(config =>
            {
                config.DefaultApiVersion = new ApiVersion(1, 0);
                config.AssumeDefaultVersionWhenUnspecified = true;
                config.ReportApiVersions = true;
            });
        }
    }
}
