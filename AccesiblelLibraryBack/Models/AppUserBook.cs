using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.Models
{
    public class AppUserBook
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int BookId { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
