using AccessibleLibrary.DAL;
using AccessibleLibrary.Extensions;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
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
    public class UpdatesBookController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public UpdatesBookController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {

            List<Book> books = await _db.Books.Where(b => b.IsDeleted == false && b.IsUpdate == true && b.IsActive == true).Include(b => b.BookImages).Include(i => i.BookDetail).ToListAsync();
            return View(books);
        }

        public async Task<IActionResult> TrueUpdated(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            Book book = await _db.Books.
                Where(b => b.IsUpdate == true && b.IsDeleted == false && b.IsActive == true)
                .Include(b => b.AppUser).Include(b => b.BookImages).Include(b => b.BookLanguage).
                Include(b => b.BookCategories).ThenInclude(c=>c.Category).Include(b => b.AppUserBooks).Include(b => b.BookDetail)
                .ThenInclude(b => b.BookCity).FirstOrDefaultAsync(b => b.Id == id);
            BookDetail detail = await _db.BookDetails.FirstOrDefaultAsync(b => b.BookId == id);
            if (book == null) return RedirectToAction(nameof(Index));
            BookUpdate bookUpdate = await _db.BookUpdates.FirstOrDefaultAsync(b => b.BookId == id);
            book.Name = bookUpdate.Name;
            book.Auhtor = bookUpdate.Author;
            book.Price = bookUpdate.Price;
            book.Phone = bookUpdate.Phone;
            book.SalerName = bookUpdate.SalerName;
            book.Email = bookUpdate.Email;
            book.BookLanguageId = bookUpdate.LanguageId;
            detail.BookCityId = (int)bookUpdate.CityId;
            foreach (BookCategory bc in book.BookCategories)
            {
                if (bookUpdate.ChildCatId != 0)
                {


                    bc.CategoryId = (int)bookUpdate.ChildCatId;
                    _db.BookCategories.Update(bc);

                }
                else
                {

                    bc.CategoryId = bookUpdate.MainCatId;
                    _db.BookCategories.Update(bc);

                }
            }
            book.IsUpdate = false;
            _db.Books.Update(book);
            _db.BookDetails.Update(detail);
            _db.BookUpdates.Remove(bookUpdate);
            await _db.SaveChangesAsync();


            //**********************************************************
            //***************for Created book to User
            string url = "http://jrcomerun14-001-site1.btempurl.com/Books/Detail/" + $"{book.Id}";
            string subject2 = "Kitab Dəyışdirldi";
            string message2 = $"<a href='{url}'> Kitab elavə olundu bu kitaba girib baxa bilərsiniz</a>";
            string mailto = "kamranfn@code.edu.az";
            await Helper.SendMessage(subject2, message2, mailto);
            return RedirectToAction("Index");
        }

        #region Delete Update Book
        public async Task<IActionResult> Delete(int? id)
        {
            UpdateBookVM bookVM = new UpdateBookVM
            {
                Book = await _db.Books.Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                Include(b => b.BookDetail).ThenInclude(b => b.BookCity).Include(b=>b.BookCategories).ThenInclude(b=>b.Category).ThenInclude(c=>c.Parent).FirstOrDefaultAsync(b => b.Id == id),
                BookUpdate = await _db.BookUpdates.FirstOrDefaultAsync(b => b.BookId == id),
            };
            if (id == null) return RedirectToAction(nameof(Index));
            if (bookVM.Book == null) return RedirectToAction(nameof(Index));
            if (bookVM.BookUpdate == null) return RedirectToAction(nameof(Index));
            ViewBag.Child = null;
            Category category = await _db.Categories.FirstOrDefaultAsync(c => c.Id == bookVM.BookUpdate.ChildCatId);
            if (category != null)
            {
                ViewBag.Child = category.Name;
            }
            ViewBag.Main = (await _db.Categories.FirstOrDefaultAsync(c => c.Id == bookVM.BookUpdate.MainCatId)).Name;
            ViewBag.Lang = (await _db.BookLanguages.FirstOrDefaultAsync(c => c.Id == bookVM.BookUpdate.LanguageId)).Name;
            ViewBag.City = (await _db.BookCities.FirstOrDefaultAsync(c => c.Id == bookVM.BookUpdate.CityId)).Name;
            return View(bookVM);
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
            BookUpdate bookUpdate = await _db.BookUpdates.FirstOrDefaultAsync(b => b.BookId == id);
            book.IsUpdate = false;
            _db.Books.Update(book);
            _db.BookUpdates.Remove(bookUpdate);
            await _db.SaveChangesAsync();
            string subject2 = "Elan Yeniləmə";
            string message2 = $"Kitab Dəyışdirilmədi";
            string mailto = book.Email;
            await Helper.SendMessage(subject2, message2, mailto);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}