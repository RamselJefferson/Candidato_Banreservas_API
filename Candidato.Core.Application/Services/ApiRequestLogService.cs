using AutoMapper;
using Candidato.Core.Application.Dto;
using Candidato.Core.Application.Filter;
using Candidato.Core.Application.Interfaces.Repositories;
using Candidato.Core.Application.Interfaces.Services;
using Candidato.Core.Application.Request;
using Candidato.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Candidato.Core.Application.Services
{
    public class ApiRequestLogService : BaseService<CandidatoRequest, UpdateCandidatoRequest, ApiMertricsDto, ApiMetrics>, IApiRequestLogService
    {
        private readonly IApiRequestLogRepository _repo;

    private readonly IMapper _mapper;

    public ApiRequestLogService(IApiRequestLogRepository repo, IMapper mapper) : base(repo, mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

        public async Task<List<ApiMertricsDto>> GetReport(string connectionString, ReportFilter filter)
        {
            var metrics = new List<ApiMertricsDto>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("ReporteApiRequest", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FECHAINICIO", filter.FechaInicial);
                    command.Parameters.AddWithValue("@FECHAFINAL", filter.FechaFinal);



                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                                           
                            metrics.Add(new ApiMertricsDto
                            {
                                HttpMethod = reader["HttpMethod"].ToString(),
                                TransaccionesPorMinuto = int.Parse(reader["TransaccionesPorMinuto"].ToString()),
                                PromedioRespuestaMs = int.Parse(reader["PromedioRespuestaMs"].ToString()),
                                Result = int.Parse(reader["Result"].ToString()),
                                EndPoint = reader["EndPoint"].ToString(),
                                CantidadPeticion = int.Parse(reader["CantidadPeticion"].ToString())
                            }) ;
                        }
                    }
                }
            }

            return metrics;
        }
    }
}
