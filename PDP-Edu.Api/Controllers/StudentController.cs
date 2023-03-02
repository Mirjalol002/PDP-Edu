using Microsoft.AspNetCore.Mvc;

namespace PDP_Edu.Api.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
