using AccessibleLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.ViewModels
{
    public class AddBookVM
    {
        public Book Book { get; set; }
        public List<BookLanguage> BookLanguages { get; set; }
        public List<BookCity> BookCities { get; set; }
        public List<BookCategory> BookCategories { get; set; }
    }
}
