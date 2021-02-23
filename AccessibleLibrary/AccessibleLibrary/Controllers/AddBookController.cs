using AccessibleLibrary.DAL;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Controllers
{
    public class AddBookController : Controller
    {
        private readonly AppDbContext _db;
        public AddBookController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //BooksVM booksVM = new BooksVM
            //{
            //    Categories = _db.Categories.ToList(),
            //    BookCities = _db.BookCities.ToList(),
            //    BookLanguages =_db.BookLanguages.ToList(),
            //};
            ViewBag.MainCat = _db.Categories.Where(c => c.IsMain == true).ToList();
            ViewBag.ChildCat = _db.Categories.Where(c => c.IsMain == false).ToList();
            ViewBag.Languages = _db.BookLanguages.ToList();
            ViewBag.Cities = _db.BookCities.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Book book, int? MainCatId)
        {
            return View();
        }
        public IActionResult LoadChildCategory( int? MainCatId)
        {
            if (MainCatId == null) return View("Error");
            List<Category> categories = _db.Categories.Where(c=>c.IsMain==false&&c.ParentId==MainCatId).ToList();
            return PartialView("_ChildCategoriesPartial", categories);
        }
    }
}
