using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Auhtor { get; set; }
        public string Price { get; set; }
        public int ViewCount { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public BookDetail BookDetail { get; set; }
        public int BookLanguageId { get; set; }
        public BookLanguage BookLanguage { get; set; }
        
        public int BookImageId { get; set; }
        public BookImage BookImage { get; set; }



    }
}
