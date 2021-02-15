using AccesiblelLibraryBack.DAL;
using AccesiblelLibraryBack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.ViewComponents
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
