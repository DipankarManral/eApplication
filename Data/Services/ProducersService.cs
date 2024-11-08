using eApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eApplication.Data.Services
{
    public class ProducersService: IProducersService
    {
        private readonly AppDbContext _context;

        public ProducersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Producer producer)
        {
            await _context.Producers.AddAsync(producer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var data = await _context.Producers.FirstOrDefaultAsync(x => x.Id == id);

            _context.Producers.Remove(data);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Producer>> GetAllAsync()
        {
            var data = await _context.Producers.ToListAsync();

            return data;

        }

        public async Task<Producer> GetByIdAsync(int id)
        {
            return await _context.Producers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Producer> UpdateAsync(int id, Producer newproducer)
        {
            var data = _context.Update(newproducer);
            await _context.SaveChangesAsync();
            return newproducer;
        }
    }
}
    
