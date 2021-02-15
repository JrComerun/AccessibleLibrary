using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public  Category Parent { get; set; }
        public ICollection<Category> Children { get; set; }
        public List<BookCategory> BookCategories { get; set; }

    }
}
