using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class BookImage
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public bool IsMain { get; set; }
        public virtual BookImage Parent { get; set; }

        public virtual ICollection<BookImage> Children { get; set; }
        public virtual Book Book { get; set; }
    }
}
