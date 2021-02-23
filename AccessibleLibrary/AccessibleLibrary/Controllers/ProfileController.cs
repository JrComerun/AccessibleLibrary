using AccessibleLibrary.DAL;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _usermanager;
        private readonly IWebHostEnvironment _env;
        public ProfileController(AppDbContext db, UserManager<AppUser> usermanager, IWebHostEnvironment env)
        {
            _db = db;
            _usermanager = usermanager;
            _env = env;
        }
        public async Task<IActionResult> Index(string username , string active)
        {
            if (username == null) return View("Error");
            AppUser userProfile = await _usermanager.FindByNameAsync(username);
            if (userProfile == null) return View("Error");
            if (username == User.Identity.Name)
            {
                ViewBag.User = "User";
            }
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            ProfileVM profile = new ProfileVM()
            {
                User = userProfile,
                ActiveBooks = _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                b.IsActive == true && b.AppUser.UserName.ToLower().Trim() == username.ToLower().Trim()).Include(b => b.BookImages).
                Include(b=>b.BookLanguage).Include(b=>b.AppUserBooks).ToList(),
                DeActiveBooks = _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                b.IsActive == false && b.AppUser.UserName.ToLower().Trim() == username.ToLower().Trim()).Include(b => b.BookImages).
                Include(b => b.BookLanguage).Include(b => b.AppUserBooks).ToList(),
                BookMark= _db.AppUserBooks.Where(b=>b.AppUser.UserName==User.Identity.Name).ToList(),
            };
            ViewBag.Active = "Bookmark";
            return View(profile);
        }
        [HttpPost]
        public async Task BookMark(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                Book book = await _db.Books.Include(b=>b.AppUserBooks).FirstOrDefaultAsync(b => b.Id == id);
                bool IsBookmark = book.AppUserBooks.Any(b => b.AppUserId == user.Id);
                if (IsBookmark == false)
                {

                    AppUserBook bookmark = new AppUserBook
                    {
                        AppUserId = user.Id,
                        BookId = id
                    };
                    book.AppUserBooks.Add(bookmark);
                }
                else
                {
                    book.AppUserBooks.Remove(book.AppUserBooks.FirstOrDefault());
                }
                await _db.SaveChangesAsync();
            }

        }
    }
}
