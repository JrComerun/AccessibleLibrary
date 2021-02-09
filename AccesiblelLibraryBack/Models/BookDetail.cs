using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public Book Book { get; set; }
        public int BookCityId { get; set; }
        public BookCity BookCity { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }
}
