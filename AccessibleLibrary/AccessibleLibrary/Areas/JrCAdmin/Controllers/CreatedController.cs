using AccessibleLibrary.DAL;
using AccessibleLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Areas.JrCAdmin.Controllers
{
    [Area("JrCAdmin")]
    [Authorize(Roles = "Admin")]
    public class CreatedController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public CreatedController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.PageCount = Decimal.Ceiling((decimal)_db.Books.Where(b => b.IsDeleted == false && 
            b.IsCreated == true && b.IsActive == true).Count() / 8);

            ViewBag.Page = page;
            List<Book> books = await _db.Books.Where(b => b.IsDeleted == false && b.IsCreated == true && b.IsActive == true).
                OrderByDescending(d => d.Id).Skip(((int)page - 1) * 8).Take(8).Include(b => b.BookImages).
                Include(i => i.BookDetail).ToListAsync();

            return View(books);
        }
        
        #region Delete Book
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            Book book = await _db.Books.Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                Include(b => b.BookDetail).ThenInclude(b => b.BookCity).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return RedirectToAction(nameof(Index));
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            Book book = await _db.Books.Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                Include(b => b.BookDetail).ThenInclude(b => b.BookCity).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return RedirectToAction(nameof(Index));
            foreach (BookImage image in book.BookImages)
            {
                string folder = Path.Combine("src", "img", "books");
                string path = Path.Combine(_env.WebRootPath, folder, image.Image);
                if (System.IO.File.Exists(path))
                {
                    System.IO.File.Delete(path);

                }
            }
            _db.BookDetails.Remove(book.BookDetail);
            _db.Books.Remove(book);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
