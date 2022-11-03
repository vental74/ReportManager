using Microsoft.AspNetCore.Mvc;
using ReportManager.Application.Mediatr.Report.Commands;
using ReportManager.Application.Model;
using ReportManager.Application.Services;
using ReportManager.Domain;

namespace ReportManager.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : Controller
    {
        private readonly ReportService _service;
        private readonly MediatR.IMediator _mediator;
        public ReportController(ReportService service,MediatR.IMediator mediator)
        {
            _service = service;
            _mediator=mediator;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result =await _service.GetReport(id);
            return result == null ? Results.NotFound() : Results.Ok(result);
        }
        
        [HttpPost]
        public async Task<IResult> Create(CreateReportCommand command)
        {
            await _mediator.Send(command);
            return Results.Ok();
        }
    }
}
