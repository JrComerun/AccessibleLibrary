using AccesiblelLibraryBack.DAL;
using AccesiblelLibraryBack.Models;
using AccesiblelLibraryBack.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _db;
        public readonly UserManager<AppUser> _usermanager;
        public readonly IWebHostEnvironment _env;
        public ProfileController(AppDbContext db, UserManager<AppUser> usermanager, IWebHostEnvironment env)
        {
            _db = db;
            _usermanager = usermanager;
            _env = env;
        }
        public async Task<IActionResult> Index(string username)
        {
            if (username == null) return View("Error");
            AppUser userProfile = await _usermanager.FindByNameAsync(username);
            if (userProfile == null) return View("Error");
            if (username == User.Identity.Name)
            {
                ViewBag.User = "User";
            }
            ProfileVM profile = new ProfileVM()
            {
                User = userProfile,
                ActiveBooks = _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                b.IsActive == true && b.AppUser.UserName.ToLower().Trim() == username.ToLower().Trim()).Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                Include(b => b.AppUserBooks).ThenInclude(b => b.AppUser).ToList(),
                DeActiveBooks = _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                b.IsActive == false && b.AppUser.UserName == username).Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                Include(b => b.AppUserBooks).ThenInclude(b => b.AppUser).ToList(),
                
            };
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            return View(profile);
    }
    [HttpPost]

    public async Task BookMark(int? id)
    {
        if (User.Identity.IsAuthenticated)
        {
            AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
            //if (id == null) return View("Error");
            Book book = await _db.Books.Include(b => b.AppUserBooks).FirstOrDefaultAsync(b => b.Id == id);
            bool IsBookmark = book.AppUserBooks.Any(b => b.AppUserId == user.Id);
            if (IsBookmark == false)
            {

                AppUserBook bookmark = new AppUserBook
                {
                    AppUserId = user.Id,
                    BookId = (int)id
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
