using Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        
        [HttpGet("details")]
        public async Task<IActionResult> GetDashboardDetails()
        {
            return Ok(await _dashboardService.GetDashboardDetails());
        }
    }
}
