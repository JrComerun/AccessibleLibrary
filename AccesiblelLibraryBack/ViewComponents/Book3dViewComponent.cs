using AccesiblelLibraryBack.DAL;
using AccesiblelLibraryBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.ViewComponents
{
    public class Book3dViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;
        public readonly UserManager<AppUser> _usermanager;

        public Book3dViewComponent(AppDbContext db, UserManager<AppUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Book> Books = _db.Books.OrderByDescending(b=>b.ViewCount).Where(b => b.IsCreated == true && b.IsDeleted == false &&
            b.IsActive == true).Take(4).Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
            Include(b => b.AppUserBooks).ThenInclude(b => b.AppUser).ToList();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
           

            return View(await Task.FromResult(Books));
        }
    }
}
