using AutoMapper;
using Candidato.Core.Application.Dto;
using Candidato.Core.Application.Interfaces.Repositories;
using Candidato.Core.Application.Interfaces.Services;
using Candidato.Core.Application.Request;
using Candidato.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Services
{
    public class CandidatoService : BaseService<CandidatoRequest, UpdateCandidatoRequest, CandidatoDTO, Candidatos>, ICandidatoService
    {
        private readonly ICandidatoRepository _repo;

        private readonly IMapper _mapper;
       
        public CandidatoService(ICandidatoRepository repo, IMapper mapper) : base(repo, mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async  Task<CandidatoDTO> AddAsync(CandidatoRequest request)
        {

            var entity = _mapper.Map<Candidatos>(request);
            entity.FechaAplicacionPuesto = DateTime.Now;

            entity = await _repo.AddAsync(entity);
            return _mapper.Map<CandidatoDTO>(entity);

        }

     
        public async Task<bool> ExistCandidato(int id)
        {
            var listCandidatos = await _repo.GetAllAsync();
            if (listCandidatos.Count() == 0)
            {
                return false;
            }
      
            return true;

        }


        public async Task<CandidatoDTO> UpdateCandidate(UpdateCandidatoRequest request)
        {
            var candidate = await _repo.GetByIdAsync(request.Id);

            _mapper.Map(request, candidate);

            await _repo.UpdateAsync(candidate);
           
            return _mapper.Map<CandidatoDTO>(candidate);

        }




    }
}
