using AccesiblelLibraryBack.Models;
using AccesiblelLibraryBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesiblelLibraryBack.ViewModels
{
    public class LayoutVM
    {
        public LoginVM LoginVM { get; set; }
        public RegisterVM RegisterVM { get; set; }
        public AppUser AppUser { get; set; }
    }
}
