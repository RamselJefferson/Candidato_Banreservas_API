using Candidato.Core.Application.Dto;
using Candidato.Core.Application.Request;
using Candidato.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Interfaces.Services
{
    public interface ICandidatoService : IBaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>
    {
        new Task<CandidatoDTO> AddAsync(CandidatoRequest request);
    

        Task<bool> ExistCandidato(int id);

        Task<CandidatoDTO> UpdateCandidate(UpdateCandidatoRequest request);
    }
}
