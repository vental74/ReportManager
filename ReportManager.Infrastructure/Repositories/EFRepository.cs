using Microsoft.EntityFrameworkCore;
using ReportManager.Domain.Interfaces;
using ReportManager.Infrastructure.EFCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Infrastructure.Repositories
{
    public class EFRepository<T> : IRepository<T> where T: class
    {
        private readonly ReportManagerDbContext _context;
        public EFRepository(ReportManagerDbContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T item)
        {
            await _context.AddAsync<T>(item);
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<T> Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
        public async Task<T> Delete(T item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
