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
            Book book = await _db.Books.FirstOrDefaultAsync(b=>b.Id==id);
            BookDetail detail = await _db.BookDetails.FirstOrDefaultAsync(b=>b.BookId==id);
            if (book == null) return RedirectToAction(nameof(Index));
            if (detail == null) return RedirectToAction(nameof(Index));
            book.IsCreated = true;
            detail.IsCreated = true;
             _db.Books.Update(book);
             _db.BookDetails.Update(detail);
            await _db.SaveChangesAsync();
            //*************************************************
            //*****************Send Subscrribes****************

            List<SubScribe> subScribes = await _db.SubScribes.ToListAsync();
            foreach (SubScribe s in subScribes)
            {
                BookSubScribe bookSubScribe = new BookSubScribe();
                bookSubScribe.BookId = book.Id;
                bookSubScribe.SubScribeId = s.Id;
                await _db.BookSubScribes.AddAsync(bookSubScribe);
                await _db.SaveChangesAsync();
            }
            string url = "http://jrcomerun14-001-site1.btempurl.com/Books/Detail/" + $"{book.Id}";
            string subject1 = "Yeni Kitab ";
            string message1 = $"<a href='{url}'> Yeni Kitab elavə olundu bu kitaba girib baxa bilərsiniz</a>";
            List<BookSubScribe> bookSubScribes = _db.BookSubScribes.Where(s => s.BookId == book.Id).ToList();
            foreach (BookSubScribe s in bookSubScribes)
            {
                await Helper.SendMessage(s.SubScribe.Email, subject1, message1);
            }
            //**********************************************************
            //***************for Created book to User
            string subject2 = "Kitab Dəyışdirildi";
            string message2 = $"<a href='{url}'> Kitab elavə olundu bu kitaba girib baxa bilərsiniz</a>";
            string mailto = book.Email;
            await Helper.SendMessage(subject2, message2, mailto);
            return RedirectToAction("Index");
        }

        #region Delete Book
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return RedirectToAction(nameof(Index));
            Book book = await _db.Books.Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                Include(b => b.BookDetail).ThenInclude(b => b.BookCity).Include(c => c.BookCategories).ThenInclude(c=>c.Category).ThenInclude(c=>c.Parent).FirstOrDefaultAsync(b => b.Id == id);
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
                _db.BookImages.Remove(image);
            }
            _db.BookDetails.Remove(book.BookDetail);
            _db.Books.Remove(book);  
            await _db.SaveChangesAsync();
            string subject2 = "Elan Yerləşdirmə";
            string message2 = $"Kitab elavə olunmadı";
            string mailto = book.Email;
            await Helper.SendMessage(subject2, message2, mailto);
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
