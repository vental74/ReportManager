using Microsoft.EntityFrameworkCore;
using ReportManager.Domain.Interfaces;
using ReportManager.Infrastructure.EFCore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Infrastructure.Repositories
{
    public class EFUpdateRepository<T> : IUpdateRepository<T> where T : class
    {
        private readonly ReportManagerDbContext _context;
        public EFUpdateRepository(ReportManagerDbContext context)
        {
            _context = context;
        }
        public async Task<T> Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
