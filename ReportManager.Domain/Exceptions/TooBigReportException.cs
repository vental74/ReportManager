using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Domain.Exceptions
{
    public class TooBigReportException : Exception
    {
        public TooBigReportException(string message):base (message)
        {

        }
    }
}
