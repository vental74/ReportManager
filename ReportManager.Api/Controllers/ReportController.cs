using Microsoft.AspNetCore.Mvc;
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
        public ReportController(ReportService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IResult> Get(int id)
        {
            var result =await _service.GetReport(id);
            return result == null ? Results.NotFound() : Results.Ok(result);
        }
        
        [HttpPost]
        public async Task<IResult> Create(ReportModel model)
        {
            await _service.AddReport(model);
            return Results.Ok();
        }
    }
}
