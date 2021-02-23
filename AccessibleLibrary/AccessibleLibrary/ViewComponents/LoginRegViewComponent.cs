
using AccessibleLibrary.DAL;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.ViewComponents
{
    public class LoginRegViewComponent:ViewComponent
    {
        private readonly AppDbContext _db;

        public LoginRegViewComponent(AppDbContext db)
        {
            _db = db;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            LayoutVM layout = new LayoutVM();

            return View(await Task.FromResult(layout));
        }
    }
}
