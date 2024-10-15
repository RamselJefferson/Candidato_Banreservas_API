using Candidato.Core.Application.Dto;
using Candidato.Core.Application.Filter;
using Candidato.Core.Application.Request;
using Candidato.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Interfaces.Services
{
    public interface IApiRequestLogService : IBaseService<CandidatoRequest, UpdateCandidatoRequest, ApiMertricsDto, ApiMetrics>
    {

         Task<List<ApiMertricsDto>> GetReport(string connectionString, ReportFilter filter);

    }
}
