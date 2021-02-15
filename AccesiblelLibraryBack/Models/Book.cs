using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
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
        public BookDetail BookDetail { get; set; }
        public int BookLanguageId { get; set; }
        public BookLanguage BookLanguage { get; set; }
        public ICollection<BookImage> BookImages { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public ICollection<AppUserBook> AppUserBooks { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }

    }
}
