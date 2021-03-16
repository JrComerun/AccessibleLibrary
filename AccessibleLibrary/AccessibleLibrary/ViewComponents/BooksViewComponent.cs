
using AccessibleLibrary.DAL;
using AccessibleLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.ViewComponents
{
    public class BooksViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _usermanager;

        public BooksViewComponent(AppDbContext db, UserManager<AppUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }
        public async Task<IViewComponentResult> InvokeAsync(string order, string view, bool isActive,  int? take)
        {
            if (take == null)
            {
                take = 4;
            }
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;

            }
            if (view == "classic")
            {
                ViewBag.View = "book-desk";
            }
            else if (view == "3d")
            {
                ViewBag.View = "book-mob mob-book";
            }
            if (order == "Id")
            {
                List<Book> Books = await _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true &&
                b.IsDeleted == false && b.IsActive == isActive).Take((int)take).Include(b => b.BookImages).
                Include(b => b.AppUser).Include(b => b.BookLanguage).Include(b => b.AppUserBooks).ToListAsync();
                return View(await Task.FromResult(Books));
            }
            else
            {
                List<Book> Books = await _db.Books.OrderByDescending(b => b.ViewCount).Where(b => b.IsCreated == true && b.IsDeleted == false &&
                b.IsActive == isActive).Take((int)take).Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).Include(b => b.AppUserBooks).ToListAsync();
                return View(await Task.FromResult(Books));
            }

        }
    }
}
