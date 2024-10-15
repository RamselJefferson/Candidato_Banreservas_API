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
  

    public class ApiRequestLogRepository : BaseRepository<ApiRequestLog>, IApiRequestLogRepository
    {
        private readonly AppDbContext _db;
        public ApiRequestLogRepository(AppDbContext db) : base(db)
        {
            _db = db;
        }

        public Task<ApiMetrics> AddAsync(ApiMetrics T)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(ApiMetrics T)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ApiMetrics? T)
        {
            throw new NotImplementedException();
        }

        Task<List<ApiMetrics>> IBaseRepository<ApiMetrics>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<ApiMetrics>> IBaseRepository<ApiMetrics>.GetAllWithIncludeAsync(List<string> props)
        {
            throw new NotImplementedException();
        }

        Task<ApiMetrics?> IBaseRepository<ApiMetrics>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
