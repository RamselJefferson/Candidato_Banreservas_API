using Candidato.Core.Application.Filter;
using Candidato.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace Candidato_Banreservas_API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApiMetricsController : ControllerBase
    {
        private readonly IApiRequestLogService _svcRequestLog;
        private readonly IConfiguration _configuration;
        public ApiMetricsController(IApiRequestLogService svcRequestLog, IConfiguration configuration)
        {
            _svcRequestLog = svcRequestLog;
            _configuration = configuration;

        }
        [HttpPost("GetMetricsApi")]
        public async Task<IActionResult> ReportRequest([FromBody] ReportFilter filter)
        {
            
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            var reportResult = await _svcRequestLog.GetReport(connectionString, filter);
            return Ok(reportResult);
        }

    }
}
