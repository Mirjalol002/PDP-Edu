using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PDP_Edu.Application.Abstractions;
using PDP_Edu.Application.Models;

namespace PDP_Edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AttendanceController : Controller
    { 
        private readonly IAttendanceService _attendanceService;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost("Check")]
        public async Task<IActionResult> AttendanceCheck(DoAttendanceCheckModel doAttendanceCheckModel)
        {
            await _attendanceService.CheckAsync(doAttendanceCheckModel);
            return Ok();
        }
    }
}
