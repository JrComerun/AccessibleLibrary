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

namespace AccessibleLibrary.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _usermanager;
        private readonly AppDbContext _db;
        public HeaderViewComponent(AppDbContext db, UserManager<AppUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
            bool IsExist = _db.SubScribes.Any(s => s.Email.ToLower().Trim() == user.Email.ToLower().Trim());
            LayoutVM layoutVM = new LayoutVM
            {
                Layout = await _db.Layout.FirstOrDefaultAsync(),
                SubScribe = await _db.SubScribes.FirstOrDefaultAsync(),
            };
            ViewBag.IsSubScribe = IsExist;
            return View(await Task.FromResult(layoutVM));
        }
    }
}
