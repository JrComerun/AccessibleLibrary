using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class BookCategory
    {
        public int Id { get; set; }
        public BookDetail BookDetail { get; set; }
        public int BookDetailId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
