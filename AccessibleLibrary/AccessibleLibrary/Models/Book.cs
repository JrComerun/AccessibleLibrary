using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz"),StringLength(25,ErrorMessage ="Maxsimum 25 hərfdən ibarət olmalıdı" )]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz"), StringLength(25, ErrorMessage = "Maxsimum 25 hərfdən ibarət olmalıdı")]
        public string Auhtor { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz")]
        public double Price { get; set; }
        public int ViewCount { get; set; }
        public bool IsCreated { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
        public bool IsActive { get; set; }
        public virtual BookDetail BookDetail { get; set; }
        public  BookLanguage BookLanguage { get; set; }
        public  int BookLanguageId { get; set; }
        public virtual ICollection<BookImage> BookImages { get; set; }

        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
        public virtual ICollection<AppUserBook> AppUserBooks { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage ="Bu xana boş ola bilməz")]
        public long Phone { get; set; }
        public string SalerName { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }

        [NotMapped]
        public IFormFile Photo { get; set; }
        [NotMapped]
        public IFormFile[] Photos { get; set; }
    }
}
