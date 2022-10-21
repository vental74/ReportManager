using ReportManager.Domain;
using ReportManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportManager.Application.Services
{
    public class ReportService
    {
        private readonly IRepository<ReportEntity> _repository;
        public ReportService(IRepository<ReportEntity> repository)
        {
            _repository = repository;
        }
        public async Task<ReportEntity> GetReport() 
        {
            return  await _repository.Get(x => x.Id == 1);
        }
    }
}
