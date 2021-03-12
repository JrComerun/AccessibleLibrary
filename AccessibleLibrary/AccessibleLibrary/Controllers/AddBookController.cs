using AccessibleLibrary.DAL;
using AccessibleLibrary.Extensions;
using AccessibleLibrary.Models;
using AccessibleLibrary.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class AddBookController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<AppUser> _userManager;
        public AddBookController(AppDbContext db, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _db = db;
            _env = env;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.Name = user.Name;
            ViewBag.Email = user.Email;
            await GetBookRelationTablesAsync();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Book book, int? MainCatId, List<int?> ChildCatId, int? LanguageId, int? CityId)
        {
            await GetBookRelationTablesAsync();
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.Name = user.Name;
                ViewBag.Email = user.Email;
                if (!ModelState.IsValid) return View();
                if (MainCatId == null) return IsNonValid("MainCatId", "Zəhmət olmasa Kateqoriya seçin!");
                if (book.Photo == null) return IsNonValid("Photo", "Əsas şəkil mütləq olmalıdır! ");
                if (!book.Photo.IsImage()) return IsNonValid("Photo", "Zəhmət olmasa şəkil seçin!");
                if (LanguageId == null) return IsNonValid("LanguageId", "Zəhmət olmasa dili seçin!");
                if (CityId == null) return IsNonValid("CityId", "Zəhmət olmasa dili seçin!");
                if (book.Photos != null)
                {
                    if (book.Photos.Length > 4) return IsNonValid("Photos", "Maxsimum şəkil 4 ola Bilər!");
                }

                string folder = Path.Combine("src", "img", "books");
                string filename1 = book.Photo.SaveImagesAsync(_env.WebRootPath, folder);
                List<BookImage> images = new List<BookImage>();
                BookImage image = new BookImage
                {
                    Image = filename1,
                    IsMain = true,
                    BookId = book.Id,

                };
                images.Add(image);


                book.BookImages = images;

                book.AppUserId = user.Id;
                book.ViewCount = 1;
                book.IsActive = true;
                book.IsCreated = false;
                book.IsDeleted = false;
                book.BookLanguageId = (int)LanguageId;
                if (book.Photos != null)
                {
                    foreach (IFormFile img in book.Photos)
                    {
                        if (!img.IsImage())
                        {
                            return IsNonValid("", "Zəhmət olmasa şəkil seçin!");
                        }
                        string filename2 = img.SaveImagesAsync(_env.WebRootPath, folder);
                        BookImage image2 = new BookImage
                        {
                            Image = filename2,
                            IsMain = false,
                            BookId = book.Id,
                            ParentId = image.Id,
                        };
                        images.Add(image2);
                    }

                }
                List<BookCategory> bookCategories = new List<BookCategory>();
                if (MainCatId != null)
                {
                    if (await _db.Categories.Where(c => c.IsMain == false && c.ParentId == MainCatId).ToListAsync() != null)
                    {
                        foreach (BookCategory bc in bookCategories)
                        {
                            bc.BookId = book.Id;
                            foreach (int ct in ChildCatId)
                            {
                                bc.CategoryId = ct;
                            }
                            await _db.BookCategories.AddAsync(bc);

                        }
                    }
                    else
                    {
                        foreach (BookCategory bc in bookCategories)
                        {
                            bc.BookId = book.Id;
                            bc.CategoryId = (int)MainCatId;
                        }
                    }
                }

                BookDetail bookDetail = new BookDetail();
                bookDetail.CreateTime = DateTime.Now;
                bookDetail.BookId = book.Id;
                bookDetail.Book = book;
                bookDetail.BookCityId = (int)CityId;
                bookDetail.IsCreated = false;
                bookDetail.IsDeleted = false;
                await _db.BookDetails.AddAsync(bookDetail);
                await _db.SaveChangesAsync();
                BookImage imageDb = await _db.BookImages.FirstOrDefaultAsync(i => i.BookId == book.Id);

                book.BookImages = images;
                await _db.SaveChangesAsync();
                string subject = "Yeni Kitab";
                string message = "Boş Boş fırlanma Get kitaba bax sonra təsdiqlə a bala ";
                string mailto = "kamranfn@code.edu.az";
                await Helper.SendMessage(subject,message, mailto);
            }
            else
            {
                return View("Error");
            }

            return RedirectToAction("WaitBookCreate", "AddBook");
        }
        public async Task<IActionResult> LoadChildCategory(int? MainCatId)
        {
            if (MainCatId == null) return View("Error");
            List<Category> categories = await _db.Categories.Where(c => c.IsMain == false && c.ParentId == MainCatId).ToListAsync();
            return PartialView("_ChildCategoriesPartial", categories);
        }

        #region My IsNonValid Metods
        public ActionResult IsNonValid(string errorName, string errorContent)
        {
            ModelState.AddModelError(errorName, errorContent);
            return View();
        }
        public ActionResult IsNonValid(string errorName, string errorContent, object returnObj)
        {
            ModelState.AddModelError(errorName, errorContent);
            return View(returnObj);
        }
        #endregion
        public async Task GetBookRelationTablesAsync()
        {
            ViewBag.MainCat = await _db.Categories.Where(c => c.IsMain == true).ToListAsync();
            ViewBag.ChildCat = await _db.Categories.Where(c => c.IsMain == false && c.ParentId == 1).ToListAsync();
            ViewBag.Languages = await _db.BookLanguages.ToListAsync();
            ViewBag.Cities = await _db.BookCities.ToListAsync();
        }
        public IActionResult WaitBookCreate(int? MainCatId)
        {
            return View();
        }
    }
}
