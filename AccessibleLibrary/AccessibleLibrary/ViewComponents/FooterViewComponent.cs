using AccessibleLibrary.DAL;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.ViewComponents
{
    public class FooterViewComponent : ViewComponent
    {
        private readonly AppDbContext _db;
        public FooterViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            LayoutVM layoutVM = new LayoutVM
            {
                Layout = await _db.Layout.FirstOrDefaultAsync(),
                Thanks = await _db.Thanks.ToListAsync(),
                RelationSites = await _db.RelationSites.ToListAsync(),
            };
            return View(await Task.FromResult(layoutVM));
        }
    }
}
