using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Bu xana doldurulmalıdır")]
        [RegularExpression(@"^(?:.*[a-z]){6,}$", ErrorMessage = "Bu xanadakı hərflərin sayı 6-dan yuxarı olmalıdır")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır")]
        [RegularExpression(@"^(?:.*[a-z]){6,}$", ErrorMessage = "Bu xanadakı hərflərin sayı 6-dan yuxarı olmalıdır")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır")]
        [RegularExpression(@"^(?:.*[a-z]){6,}$", ErrorMessage = "Bu xanadakı hərflərin sayı 6-dan yuxarı olmalıdır")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.EmailAddress,ErrorMessage ="Email düzgün deyil")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.Password,ErrorMessage = "Şifrə formatı düzgün deyil")]
        [RegularExpression(@"^(?:.*[a-z]){6,}$", ErrorMessage = "Bu xanadakı hərflərin sayı 6-dan yuxarı olmalıdır")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.Password, ErrorMessage = "Şifrə formatı düzgün deyil"), Compare(nameof(Password), ErrorMessage = "Şifrə təkrarı düzgün deyil")]
        public string CheckPassword { get; set; }
    }
}
