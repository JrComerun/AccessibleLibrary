using AccessibleLibrary.DAL;
using AccessibleLibrary.Extensions;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
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
        public async Task<IActionResult> Index(string username, string active)
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
                ActiveBooks = await _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                 b.IsActive == true && b.AppUser.UserName.ToLower().Trim() == username.ToLower().Trim()).Include(b => b.BookImages).
                Include(b => b.BookLanguage).Include(b => b.AppUserBooks).ToListAsync(),
                DeActiveBooks = await _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                b.IsActive == false && b.AppUser.UserName.ToLower().Trim() == username.ToLower().Trim()).Include(b => b.BookImages).
                Include(b => b.BookLanguage).Include(b => b.AppUserBooks).ToListAsync(),
                BookMark = await _db.AppUserBooks.Where(b => b.AppUser.UserName == User.Identity.Name).ToListAsync(),
            };
            ViewBag.Active = active;
            return View(profile);
        }
        [HttpPost]
        public async Task BookMark(int id)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                Book book = await _db.Books.Include(b => b.AppUserBooks).FirstOrDefaultAsync(b => b.Id == id);
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

        public async Task<IActionResult> ChangeProfileImage(IFormFile Photo)
        {
            if (Photo == null) return Content("Şəkil boşdur");

            AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
            if (user == null) return Content("Belə bir istifadəçi yoxdur");
            if (!Photo.IsImage()) return Content("Bu Şəkil deyil");
            string folder = Path.Combine("src", "img", "users");
            string filename = Photo.SaveProfileImageAsync(_env.WebRootPath, folder);
            user.Image = filename;
            await _usermanager.UpdateAsync(user);
            return Content("Şəkil dəyişdirildi");
        }
          
        public async Task<IActionResult> ChangeProfileDetail(string SUsername,string SLastname ,string SFirstname)
        {
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                AppUser dbuser = await _usermanager.FindByNameAsync(SUsername);
                if (dbuser != null) return Content("Bu İsdifadəçi adı artıq mövcuddur !");
                user.Name = SFirstname;
                user.Surname = SLastname;
                user.UserName = SUsername;
                await _usermanager.UpdateAsync(user);
                return Content("Təbriklər Dəyişdirildi !");
            }
            return Content("OLMAZ !!!");
        }
    }
}
