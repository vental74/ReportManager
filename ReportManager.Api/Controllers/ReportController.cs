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
        public Task<ReportEntity> Get()
        {
            return _service.GetReport();
        }
    }
}
