using Microsoft.AspNetCore.Mvc;

namespace PDP_Edu.Api.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
