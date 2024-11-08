using eApplication.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace eApplication.Data.Services
{
    public class ActorsService :IActorsService
    {
        private readonly AppDbContext _context;
         
        public ActorsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async  Task DeleteAsync(int id)
        {
            var data= await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);

             _context.Actors.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var data = await _context.Actors.ToListAsync();

            return data;

        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            return await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Actor> UpdateAsync(int id, Actor newactor)
        {
            var data =  _context.Update(newactor);
            await _context.SaveChangesAsync();
            return newactor;
        }
    }
}
