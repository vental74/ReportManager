using Microsoft.AspNetCore.Mvc;
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
        [HttpGet(Name = "GetReport")]
        public async Task<IResult> Get(int id)
        {
            var result =await _service.GetReport(id);
            return result == null ? Results.NotFound() : Results.Ok(result);
        }
    }
}
