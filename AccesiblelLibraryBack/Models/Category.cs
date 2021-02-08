using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public List<Category> Children { get; set; }
        public List<BookCategory> BookCategories { get; set; }

    }
}
