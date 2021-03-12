using AccessibleLibrary.DAL;
using AccessibleLibrary.Extensions;
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
    public class UnCreatedController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        public UnCreatedController(AppDbContext db,IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<Book> books = await _db.Books.Where(b=>b.IsDeleted==false && b.IsCreated==false && b.IsActive==true).Include(b=>b.BookImages).Include(i=>i.BookDetail).ToListAsync();

            return View(books);
        }
        public async Task<IActionResult> TrueCreated(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            Book book = await _db.Books.Include(b=>b.BookDetail).FirstOrDefaultAsync(b=>b.Id==id);
            if (book == null) return RedirectToAction(nameof(Index));
            book.BookDetail.IsCreated = true;
            book.IsCreated = true;
            await _db.SaveChangesAsync();
            //*************************************************
            //*****************send Subscrribe****************

            List<SubScribe> subScribes = await _db.SubScribes.ToListAsync();
            foreach (SubScribe s in subScribes)
            {
                BookSubScribe bookSubScribe = new BookSubScribe();
                bookSubScribe.BookId = book.Id;
                bookSubScribe.SubScribeId = s.Id;
                await _db.BookSubScribes.AddAsync(bookSubScribe);
                await _db.SaveChangesAsync();
            }
            string url = "https://localhost:44366/Book/Detail/" + $"{book.Id}";
            string subject = "Yeni Kitab ";
            string message = $"<a href='{url}'> Kitab elavə olundu bu kitaba girib baxa bilərsiniz</a>";
            List<BookSubScribe> bookSubScribes = _db.BookSubScribes.Where(s => s.BookId == book.Id).ToList();
            foreach (BookSubScribe s in bookSubScribes)
            {
                await Helper.SendMessage(s.SubScribe.Email, subject, message);
            }
            return RedirectToAction("Index");
        }
        #region Delete Event
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
