using eApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eApplication.Data.Services
{
    public class CinemasService:ICinemasService     

    {
        private readonly AppDbContext _context;

        public CinemasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Cinema Cinema)
        {
            await _context.Cinemas.AddAsync(Cinema);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);

            _context.Cinemas.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            var data = await _context.Cinemas.ToListAsync();

            return data;

        }

        public async Task<Cinema> GetByIdAsync(int id)
        {
            return await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Cinema> UpdateAsync(int id, Cinema newCinema)
        {
            var data = _context.Update(newCinema);
            await _context.SaveChangesAsync();
            return newCinema;
        }
    }
}
