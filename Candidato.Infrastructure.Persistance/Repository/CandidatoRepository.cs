using Candidato.Core.Application.Interfaces.Repositories;
using Candidato.Core.Domain.Entities;
using Candidato.Infrastructure.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Infrastructure.Persistance.Repository
{
    public class CandidatoRepository : BaseRepository<Candidatos>, ICandidatoRepository
    {
        private readonly AppDbContext _db;
        public CandidatoRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

       
    }
}
