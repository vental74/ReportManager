using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task<T> Create(T item);
        Task<IEnumerable<T>> Get();
        Task<T> Get(Expression<Func<T,bool>> predicate);
        Task<T> Update(T item);
        Task<T> Delete(T item);
    }
}
