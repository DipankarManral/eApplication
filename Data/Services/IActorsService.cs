using eApplication.Models;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace eApplication.Data.Services
{
    public interface IActorsService

    {

          Task<IEnumerable<Actor>> GetAllAsync();
          Task<Actor> GetByIdAsync(int id);
          
          Task  AddAsync (Actor actor);

        Task<Actor> UpdateAsync(int id, Actor actor);

        Task DeleteAsync(int id);  

        


    }
}
