using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class BookImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public  BookImage Parent { get; set; }
        public ICollection<BookImage> Children { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
