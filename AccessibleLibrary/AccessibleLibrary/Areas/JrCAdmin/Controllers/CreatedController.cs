using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Areas.JrCAdmin.Controllers
{
    public class CreatedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
