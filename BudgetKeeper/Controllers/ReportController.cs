using BudgetKeeper.Resource.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BudgetKeeper.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("day")]
        public async Task<IActionResult> Get([FromQuery] DateTime day)
        {
            var report = await _reportService.GetAsync(day);

            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpGet("period")]
        public async Task<IActionResult> Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var report = await _reportService.GetAsync(from, to);

            if (report == null)
                return NotFound();

            return Ok(report);
        }

    }
}
