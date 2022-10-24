using ReportManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Application.Mapper
{
    public class FirstMapper:IMapper
    {
        private readonly AutoMapper.IMapper _autoMapper;

        public FirstMapper(AutoMapper.IMapper autoMapper)
        {
            _autoMapper = autoMapper;
        }

        public TDest Map<TSource, TDest>(TSource source)
        {
            return _autoMapper.Map<TSource, TDest>(source);
        }
    }
}
