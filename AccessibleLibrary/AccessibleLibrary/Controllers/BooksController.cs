using AccessibleLibrary.DAL;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _usermanager;

        public BooksController(AppDbContext db, UserManager<AppUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }
        public IActionResult Index()
        {

            BooksVM booksVM = new BooksVM
            {
                Categories = _db.Categories.Include(a => a.BookCategories).ToList(),
                BookCategories = _db.BookCategories.Include(a => a.Category).ToList(),
            };
            return View(booksVM);
        }
        public IActionResult Filter()
        {
            return View();

        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return View("Error");

            Book book = await _db.Books.
                Where(b => b.IsCreated == true && b.IsDeleted == false &&b.IsActive == true).Include(b => b.AppUser).Include(b => b.BookImages).Include(b => b.BookLanguage).
                Include(b => b.BookCategories).Include(b => b.AppUserBooks).Include(b => b.BookDetail).ThenInclude(b => b.BookCity).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return View("Error");
            book.ViewCount++;
            await _db.SaveChangesAsync();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            return View(book);
        }
    }
}
