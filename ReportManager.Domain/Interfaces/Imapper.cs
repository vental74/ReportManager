using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Interfaces
{
    public interface IMapper
    {
        TDest Map<TSource, TDest>(TSource source);
    }
}
