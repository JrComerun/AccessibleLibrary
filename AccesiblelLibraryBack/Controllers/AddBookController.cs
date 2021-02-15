using AccesiblelLibraryBack.DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Controllers
{
    public class AddBookController : Controller
    {
        private readonly AppDbContext _db;
        public AddBookController(AppDbContext db)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
