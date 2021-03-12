using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class BookCity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Bu xana boş ola bilməz"), StringLength(25, ErrorMessage = "Maxsimum 25 hərfdən ibarət olmalıdı")]
        public string Name { get; set; }
        public virtual ICollection<BookDetail> BookDetails { get; set; }

    }
}
