using ReportManager.Application.Model;
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
        private readonly IMapper _mapper;
        public ReportService(IRepository<ReportEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReportModel> GetReport(int id) 
        {
            var reportEntity = await _repository.Get(x => x.Id == id);
            var reportModel = _mapper.Map<ReportEntity,ReportModel>(reportEntity);
            return reportModel;
        }
        public async Task AddReport(ReportModel modelItem) 
        {
            var reportEntity = _mapper.Map<ReportModel, ReportEntity>(modelItem);
            await _repository.Create(reportEntity);
        }
    }
}
