using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class BookSubScribe
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int SubScribeId { get; set; }
        public SubScribe SubScribe { get; set; }
    }
}
