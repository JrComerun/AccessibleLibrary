using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class BookDetail
    {
        public int Id { get; set; }
        public bool IsCreated { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeleteTime { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int BookCityId { get; set; }
        public BookCity BookCity { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }
}
