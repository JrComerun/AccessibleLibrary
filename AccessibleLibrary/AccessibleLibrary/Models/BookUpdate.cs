using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class BookUpdate
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
        public string SalerName { get; set; }
        public string Email { get; set; }
        public long Phone { get; set; }
        public int BookId { get; set; }
        public int CityId { get; set; }
        public int MainCatId { get; set; }
        public int? ChildCatId { get; set; }
        public int LanguageId { get; set; }
       
        
    }
}
