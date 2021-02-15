using AccesiblelLibraryBack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.ViewModels
{
    public class ProfileVM
    {
        public List<Book> ActiveBooks;
        public List<Book> DeActiveBooks;
        public AppUser User { get; set; }
    }
}
