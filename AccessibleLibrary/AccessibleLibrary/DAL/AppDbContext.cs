using AccessibleLibrary.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCity> BookCities { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<BookImage> BookImages { get; set; }
        public DbSet<BookLanguage> BookLanguages { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<AppUserBook> AppUserBooks { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }


    }

}
