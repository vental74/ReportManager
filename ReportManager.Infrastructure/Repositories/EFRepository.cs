using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using ReportManager.Domain.Entities;
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
    public class EFRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ReportManagerDbContext _context;
        private  readonly ICache<T> _cache;
        public EFRepository(ReportManagerDbContext context, ICache<T> cache)
        {
            _context = context;
            _cache = cache;
        }
        public async Task<T> Create(T item)
        {
            await _context.AddAsync<T>(item);
            await _context.SaveChangesAsync();
            await _cache.ClearCache();
            return item;
        }
        public async Task<IEnumerable<T>> Get()//как с листом? пытаться добавить весь лист но не доставать?
        {
            var result = await _context.Set<T>().ToListAsync();
            await Task.WhenAll(result.Select(x => Task.Run(async () => await _cache.Add(x))));
            return result; 
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public async Task<T> Get(int id)
        {
            if (await _cache.TryGet(id, out var result))
                return result;
            var item = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            await _cache.Add(item);
            return item;
        }
        public async Task<T> Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            await _cache.ClearCache();
            return item;
        }
        public async Task<T> Delete(T item)
        {
            _context.Remove(item);
            await _context.SaveChangesAsync();
            await _cache.ClearCache();
            return item;
        }
    }
}
