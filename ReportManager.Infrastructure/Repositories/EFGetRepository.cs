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
    public  class EFGetRepository<T> : IGetRepository<T> where T : class
    {
        private readonly ReportManagerDbContext _context;
        public EFGetRepository(ReportManagerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<T>> Get()
        {
            return await _context.Set<T>().ToListAsync();
        }
        public async Task<T> Get(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
    }
}
