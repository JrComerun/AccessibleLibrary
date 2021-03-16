using AccessibleLibrary.DAL;
using AccessibleLibrary.Extensions;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _db;
        private readonly UserManager<AppUser> _usermanager;

        public BooksController(AppDbContext db, UserManager<AppUser> usermanager)
        {
            _db = db;
            _usermanager = usermanager;
        }
        public async Task<IActionResult> Index()
        {

            BooksVM booksVM = new BooksVM
            {
                Categories = await _db.Categories.Include(a => a.BookCategories).ToListAsync(),
                BookCategories = await _db.BookCategories.Include(a => a.Category).ToListAsync(),
            };
            return View(booksVM);
        }
        
        public async Task<IActionResult> Filter(string Key)
        {
            await GetBookRelationTablesAsync();
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Filter(string Key,int? MainCatId=0, int? ChildCatId=0)
        {
            List<Book> Books = await _db.Books.OrderByDescending(b => b.Id).Where(b => b.IsCreated == true &&
                b.IsDeleted == false && b.IsActive == true&&( b.Name==Key)).Take(24).Include(b => b.BookImages).
                Include(b => b.AppUser).Include(b => b.BookLanguage).Include(b => b.AppUserBooks).Include(c=>c.BookCategories).ThenInclude(c=>c.Category).ToListAsync();
            await GetBookRelationTablesAsync();

            if (MainCatId == 0)
            {
                return View( Books);
            }
            else
            {
                if(ChildCatId != 0)
                {
                    foreach (Book book in Books)
                    {
                        foreach (BookCategory bc in book.BookCategories)
                        {
                            if (bc.CategoryId == MainCatId || bc.CategoryId == ChildCatId)
                            {
                                return View( Books);
                            }
                        }
                    }
                }
                else
                {
                    foreach (Book book in Books)
                    {
                        foreach (BookCategory bc in book.BookCategories)
                        {
                            if (bc.Category.ParentId == MainCatId || bc.CategoryId == MainCatId)
                            {
                                return View( Books);
                            }
                        }
                    }
                }
            }
            return View( Books);

        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return View("Error");

            Book book = await _db.Books.
                Where(b => b.IsCreated == true && b.IsDeleted == false && b.IsActive == true).Include(b => b.AppUser).Include(b => b.BookImages).Include(b => b.BookLanguage).
                Include(b => b.BookCategories).ThenInclude(b=>b.Category).ThenInclude(b=>b.Parent).Include(b => b.AppUserBooks).Include(b => b.BookDetail).ThenInclude(b => b.BookCity).FirstOrDefaultAsync(b => b.Id == id);
            if (book == null) return View("Error");
            book.ViewCount++;
            await _db.SaveChangesAsync();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.UserId = user.Id;
            }
            return View(book);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return View("Error");

            if (User.Identity.IsAuthenticated)
            {
                Book book = await _db.Books.
               Where(b => b.IsCreated == true && b.IsDeleted == false && b.IsActive == true)
               .Include(b => b.AppUser).Include(b => b.BookImages).Include(b => b.BookLanguage).
               Include(b => b.BookCategories).ThenInclude(b => b.Category).ThenInclude(b => b.Children).Include(b => b.AppUserBooks).Include(b => b.BookDetail)
               .ThenInclude(b => b.BookCity).FirstOrDefaultAsync(b => b.Id == id);
                if (book == null) return View("Error");
                if (User.Identity.Name == book.AppUser.UserName || User.IsInRole("Admin"))
                {
                    await GetBookRelationTablesAsync();
                    AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                    ViewBag.Name = user.Name;
                    ViewBag.Email = user.Email;


                    return View(book);
                }
                else
                {
                    return View("Error");
                }
            }
            else
            {
                return View("Error");
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Book book, int MainCatId, int? ChildCatId, int? LanguageId, int? CityId)
        {
           
            if (id == null) return View("Error");

            Book dbBook = await _db.Books.Where(b => b.IsCreated == true && b.IsDeleted == false &&
            b.IsActive == true).Include(b=>b.AppUser).FirstOrDefaultAsync(b => b.Id == id);
            if (dbBook == null) return View("Error");
            if (User.Identity.Name == dbBook.AppUser.UserName || User.IsInRole("Admin"))
            {
                await GetBookRelationTablesAsync();
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                ViewBag.Name = user.Name;
                ViewBag.Email = user.Email;
                dbBook.IsUpdate = true;
                BookUpdate bookUpdate = new BookUpdate();
                bookUpdate.Name = book.Name;
                bookUpdate.Author = book.Auhtor;
                bookUpdate.BookId = (int)id;
                bookUpdate.ChildCatId = (int)ChildCatId;
                bookUpdate.CityId = (int)CityId;
                bookUpdate.Email = book.Email;
                bookUpdate.LanguageId = (int)LanguageId;
                bookUpdate.MainCatId = (int)MainCatId;
                bookUpdate.Phone = book.Phone;
                bookUpdate.Price = book.Price;
                bookUpdate.SalerName = book.SalerName;
                await _db.BookUpdates.AddAsync(bookUpdate);
                _db.Books.Update(dbBook);
                await _db.SaveChangesAsync();
                string subject = "Yeniləmə zamanı";
                string message = "Boş Boş fırlanma Get kitaba bax sonra yenilənməyi təsdiqlə ";
                string mailto = "kamranfn@code.edu.az";
                await Helper.SendMessage(subject, message, mailto);
            }
            return RedirectToAction("WaitBookUpdate", "Books");
        }

        #region Delete Book
        public async Task<IActionResult> Delete(int? id)
        {
            if (User.Identity.IsAuthenticated)
            {
               
                    if (id == null) return RedirectToAction(nameof(Index));
                Book book = await _db.Books.Include(b => b.BookImages).Include(b => b.AppUser).Include(b => b.BookLanguage).
                    Include(b => b.BookDetail).ThenInclude(b => b.BookCity).Include(c => c.BookCategories).ThenInclude(c => c.Category).ThenInclude(c => c.Parent).FirstOrDefaultAsync(b => b.Id == id);
                if (book == null) return RedirectToAction(nameof(Index));
                
                if (User.Identity.Name == book.AppUser.UserName || User.IsInRole("Admin"))
                {
                    return View(book);
                }
                else
                {
                    return View("Error");
                }

            }
            else 
            {
                return View("Error");
            }
            
            

            
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
            if (User.Identity.Name == book.AppUser.UserName || User.IsInRole("Admin"))
            {
                foreach (BookImage image in book.BookImages)
                {
                    string folder = Path.Combine("src", "img", "books");
                    string path = Path.Combine(folder, image.Image);
                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);

                    }
                    _db.BookImages.Remove(image);
                }
                _db.BookDetails.Remove(book.BookDetail);
                _db.Books.Remove(book);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
            
        }
        #endregion
      
        public IActionResult WaitBookUpdate()
        {
            if (User.Identity.IsAuthenticated)
            {
                return View();

            }
            else
            {
                return View("Error");
            }
        }
        public async Task<IActionResult> LoadChildCategory(int? MainCatId)
        {
            if (MainCatId == null) return View("Error");
            List<Category> categories = await _db.Categories.Where(c => c.IsMain == false && c.ParentId == MainCatId).ToListAsync();
            return PartialView("_ChildCategoriesPartial2", categories);
        }
        public async Task GetBookRelationTablesAsync()
        {
            ViewBag.MainCat = await _db.Categories.Where(c => c.IsMain == true).ToListAsync();
            ViewBag.ChildCat = await _db.Categories.Where(c => c.IsMain == false ).ToListAsync();
            ViewBag.Languages = await _db.BookLanguages.ToListAsync();
            ViewBag.Cities = await _db.BookCities.ToListAsync();
        }
    }
}
