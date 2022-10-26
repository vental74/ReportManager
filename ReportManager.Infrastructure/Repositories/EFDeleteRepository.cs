//using ReportManager.Domain.Interfaces;
//using ReportManager.Infrastructure.EFCore.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReportManager.Infrastructure.Repositories
//{
//    public class EFDeleteRepository<T> : IDeleteRepository<T> where T : class
//    {
//        private readonly ReportManagerDbContext _context;
//        public EFDeleteRepository(ReportManagerDbContext context)
//        {
//            _context = context;
//        }
//        public async Task<T> Delete(T item)
//        {
//            _context.Remove(item);
//            await _context.SaveChangesAsync();
//            return item;
//        }
//    }
//}
