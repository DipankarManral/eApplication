using eApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eApplication.Data.Services
{
    public interface IProducersService
    {
        Task<IEnumerable<Producer>> GetAllAsync();
        Task<Producer> GetByIdAsync(int id);

        Task AddAsync(Producer Producer);

        Task<Producer> UpdateAsync(int id, Producer Producer);

        Task DeleteAsync(int id);

    }
}
