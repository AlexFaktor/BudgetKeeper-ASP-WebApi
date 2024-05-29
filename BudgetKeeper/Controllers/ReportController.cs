using BudgetKeeper.Models;
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

        [HttpGet("get-day/{day:datetime}")]
        public async Task<IActionResult> Get([FromRoute] DateTime day)
        {
            var report = _reportService.Get(day);

            if (report == null)
                return NotFound();

            return Ok(report);
        }

        [HttpGet("get-period/{from:datetime}/{to:datetime}")]
        public async Task<IActionResult> Get([FromRoute] DateTime from, [FromRoute] DateTime to)
        {
            var report = _reportService.Get(from, to);

            if (report == null)
                return NotFound();

            return Ok(report);
        }

    }
}
