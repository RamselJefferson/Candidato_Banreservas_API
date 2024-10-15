using Candidato.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Text;
using Candidato.Core.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;


namespace Candidato.Infrastructure.Persistance.Middleware
{
    public class ApiRequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IServiceProvider _serviceProvider;

        public ApiRequestLoggingMiddleware(RequestDelegate next, IServiceProvider serviceProvider)
        {
            _next = next;
            _serviceProvider = serviceProvider;

        } 

        public async Task InvokeAsync(HttpContext context)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var stopWatch = new Stopwatch();
                stopWatch.Start();
                await _next(context);
                stopWatch.Stop();

                await appDbContext.ApiRequestLog.AddAsync(new ApiRequestLog
                {
                    Endpoint = context.Request.Path,
                    HttpMethod = context.Request.Method,
                    ResponseTime = stopWatch.ElapsedMilliseconds,
                    RequestTime = DateTime.Now.AddMilliseconds(-1 * stopWatch.ElapsedMilliseconds),
                    Result = context.Response.StatusCode.ToString()

                });

                await appDbContext.SaveChangesAsync();

            }


        }
    }
}
