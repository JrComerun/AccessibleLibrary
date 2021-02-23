using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required,StringLength(25)]
        public string Name { get; set; }
        [Required, StringLength(25)]
        public string Auhtor { get; set; }
        [Required]
        public int Price { get; set; }
        public int ViewCount { get; set; }
        public bool IsCreated { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsActive { get; set; }
        public virtual BookDetail BookDetail { get; set; }
        public  BookLanguage BookLanguage { get; set; }
        public virtual ICollection<BookImage> BookImages { get; set; }

        public AppUser AppUser { get; set; }
        public virtual ICollection<AppUserBook> AppUserBooks { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
