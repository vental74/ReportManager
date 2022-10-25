using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Interfaces
{
    public interface IDeleteRepository<T> where T : class
    {
        Task<T> Delete(T item);
    }
}
