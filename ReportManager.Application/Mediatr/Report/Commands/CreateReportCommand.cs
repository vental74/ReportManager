using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using ReportManager.Application.Model;
using ReportManager.Domain;
using ReportManager.Domain.Exceptions;
using ReportManager.Domain.Interfaces;

namespace ReportManager.Application.Mediatr.Report.Commands
{
    public class CreateReportCommand :IRequest<ReportModel>
    {
        public ReportModel ReportModel { get; set; }

    }
    public class CreateReportCommandHandler : IRequestHandler<CreateReportCommand, ReportModel>
    {
        private readonly IRepository<ReportEntity> _repository;
        private readonly IMapper _mapper;
        public CreateReportCommandHandler(IRepository<ReportEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<ReportModel> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            if (request.ReportModel.Report.Length > 20)
            {
                throw new TooBigReportException(request.ReportModel.Report.Length.ToString());
            }
            var reportEntity = _mapper.Map<ReportModel, ReportEntity>(request.ReportModel);
            await _repository.Create(reportEntity);
            var outputItem = _mapper.Map<ReportEntity, ReportModel>(reportEntity);
            return outputItem;
        }
    }
}
