using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz"), StringLength(50, ErrorMessage = "Maxsimum 50 hərfdən ibarət olmalıdı")]
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public virtual Category Parent { get; set; }
        public int? ParentId { get; set; }
        public virtual ICollection<Category> Children { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }

    }
}
