using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Bu xana doldurulmalıdır")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsStore { get; set; }
        
    }
}
