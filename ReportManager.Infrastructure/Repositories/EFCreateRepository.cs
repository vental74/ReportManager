//using ReportManager.Domain.Interfaces;
//using ReportManager.Infrastructure.EFCore.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReportManager.Infrastructure.Repositories
//{
//    public class EFCreateRepository<T> : ICreateRepository<T> where T : class
//    {
//        private readonly ReportManagerDbContext _context;
//        public EFCreateRepository(ReportManagerDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<T> Create(T item)
//        {
//            await _context.AddAsync<T>(item);
//            await _context.SaveChangesAsync();
//            return item;
//        }
//    }
//}
