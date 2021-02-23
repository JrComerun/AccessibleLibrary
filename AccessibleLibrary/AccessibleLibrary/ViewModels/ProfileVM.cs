
using AccessibleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.ViewModels
{
    public class ProfileVM
    {
        public List<Book> ActiveBooks;
        public List<Book> DeActiveBooks;
        public List<AppUserBook> BookMark;
        public AppUser User { get; set; }
    }
}
