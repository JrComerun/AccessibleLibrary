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
        public int ParentId { get; set; }
        public virtual BookImage Parent { get; set; }
        public List<BookImage> Children { get; set; }
        public List<Book> Books { get; set; }
    }
}
