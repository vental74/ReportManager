using ReportManager.Application.Model;
using ReportManager.Domain;
using ReportManager.Domain.Exceptions;
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
        private readonly ICreateRepository<ReportEntity> _repositoryCreate;
        private readonly IGetRepository<ReportEntity> _repositoryGet;
        private readonly IMapper _mapper;

        public ReportService(
            ICreateRepository<ReportEntity> repositoryCreate,
            IGetRepository<ReportEntity> repositoryGet,
            IMapper mapper)
        {
            _repositoryCreate = repositoryCreate;
            _repositoryGet = repositoryGet;
            _mapper = mapper;
        }
        public async Task<ReportModel> GetReport(int id) 
        {
            var reportEntity = await _repositoryGet.Get(x => x.Id == id);
            var reportModel = _mapper.Map<ReportEntity,ReportModel>(reportEntity);
            return reportModel;
        }
        public async Task AddReport(ReportModel modelItem) 
        {
            if (modelItem.Report.Length>20)
            {
                throw new TooBigReportException(modelItem.Report.Length.ToString());
            }
            var reportEntity = _mapper.Map<ReportModel, ReportEntity>(modelItem);
            await _repositoryCreate.Create(reportEntity);
        }
    }
}
