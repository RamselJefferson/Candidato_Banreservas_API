using AutoMapper;
using Candidato.Core.Application.Dto;
using Candidato.Core.Application.Request;
using Candidato.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Candidato.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {


            CreateMap<Candidatos, CandidatoDTO>()
                .ReverseMap();

            CreateMap<Candidatos, CandidatoRequest>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Candidatos, UpdateCandidatoRequest>()
                .ReverseMap();

            CreateMap<CandidatoDTO, CandidatoRequest>()
                .ReverseMap()
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<CandidatoDTO, UpdateCandidatoRequest>()
                .ReverseMap();


        }
    }
}
