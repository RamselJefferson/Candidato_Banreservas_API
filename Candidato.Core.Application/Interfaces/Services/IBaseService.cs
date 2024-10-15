using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Candidato.Core.Application.Interfaces.Services
{
    public interface IBaseService<CreateRequest, UpdateRequest, TDto, T>
          where CreateRequest : class
          where UpdateRequest : class
          where TDto : class
          where T : class
    {
        Task<List<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(int id);
        Task<TDto> AddAsync(CreateRequest request);
        Task UpdateServiceAsync(UpdateRequest request);
        Task DeleteAsync(int id);
    }
}
