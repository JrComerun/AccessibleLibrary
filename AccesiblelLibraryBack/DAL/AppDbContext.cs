using AccesiblelLibraryBack.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories;
        public DbSet<BookCity> BookCities;
        public DbSet<BookDetail> BookDetails;
        public DbSet<BookImage> BookImages;
        public DbSet<BookLanguage> BookLanguages;
        public DbSet<Category> Categories;
        public DbSet<AppUserBook> AppUserBooks;
    }
}
