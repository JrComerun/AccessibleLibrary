using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.Models
{
    public class AppUserBook
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public  Book Book { get; set; }
        public string AppUserId { get; set; }

        public  AppUser AppUser { get; set; }
    }
}
