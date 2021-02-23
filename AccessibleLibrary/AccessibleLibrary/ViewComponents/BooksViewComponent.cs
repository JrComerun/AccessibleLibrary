
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
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Book> Books = _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true && b.IsDeleted == false &&
            b.IsActive == true).Take(8).Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).Include(b => b.AppUserBooks).ToList();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            return View(await Task.FromResult(Books));
        }
    }
}
