using eApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eApplication.Data.Services
{
    public interface ICinemasService
    {
        Task<IEnumerable<Cinema>> GetAllAsync();
        Task<Cinema> GetByIdAsync(int id);

        Task AddAsync(Cinema Cinema);

        Task<Cinema> UpdateAsync(int id, Cinema Cinema);

        Task DeleteAsync(int id);
    }
}
