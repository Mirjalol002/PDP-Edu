using Microsoft.AspNetCore.Mvc;
using PDP_Edu.Application.Abstractions;

namespace PDP_Edu.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;

        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile formFile)
        {
            await _profileService.SetPhoto(formFile);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            return Ok(await _profileService.GetProfile());
        }
    }
}
