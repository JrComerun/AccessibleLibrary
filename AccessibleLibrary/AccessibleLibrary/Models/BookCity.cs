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
        [Required, StringLength(25)]
        public string Name { get; set; }
        public virtual ICollection<BookDetail> BookDetails { get; set; }

    }
}
