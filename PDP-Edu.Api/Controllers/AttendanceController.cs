﻿using Microsoft.AspNetCore.Mvc;

namespace PDP_Edu.Api.Controllers
{
    public class AttendanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
