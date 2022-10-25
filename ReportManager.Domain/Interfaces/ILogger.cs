using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Interfaces
{
    public interface ILogger
    {
        //Task Trace(string message);
        Task Debug(string message);
        Task Information(string message);
        Task Warning(string message);
        Task Error(string message);
    }
}
