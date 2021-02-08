using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class BookLanguage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
