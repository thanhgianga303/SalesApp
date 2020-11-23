using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesAppAPI.Data;

namespace SalesAppAPI.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly SalesAppContext _context;
        public Repository(SalesAppContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> GetBy(string id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Update(string id, T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(string id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}