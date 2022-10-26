using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Interfaces
{
    public interface ICache<T>
    {
        Task<T> Get(int id);
        Task Add(int id, T item);
        Task ClearCache();

        
    }
}
