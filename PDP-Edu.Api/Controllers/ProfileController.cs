using Microsoft.AspNetCore.Mvc;

namespace PDP_Edu.Api.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
