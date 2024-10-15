using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithIncludeAsync(List<string> props);
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T T);
        Task UpdateAsync(T? T);
        Task DeleteAsync(T T);
        Task SaveChanges();
    }
}
