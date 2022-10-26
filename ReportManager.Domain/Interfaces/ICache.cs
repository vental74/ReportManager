using ReportManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Interfaces
{
    public interface ICache<T> where T: BaseEntity
    {
        Task<bool> TryGet(int id, out T result);
        Task Add(T item);
        Task ClearCache();

        
    }
}
