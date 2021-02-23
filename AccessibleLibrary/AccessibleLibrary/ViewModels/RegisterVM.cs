using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AccessibleLibrary.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"),StringLength(30,ErrorMessage = "Bu xanadakı hərflərin sayı maksimum sayı 30-dur")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), StringLength(30, ErrorMessage = "Bu xanadakı hərflərin sayı maksimum sayı 30-dur")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır")]
        [RegularExpression(@"^(?=.*[a-z0-9A-Z])(?!.*\s).{4,30}$", ErrorMessage = "Bu xanadakı hərflərin sayı 4-dan yuxarı olmalıdır")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.EmailAddress, ErrorMessage = "Email düzgün deyil")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.Password, ErrorMessage = "Şifrə formatı düzgün deyil")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).{6,15}$", ErrorMessage = "Bu xanadakı hərflərin sayı 6-dan yuxarı,15-den aşagı olmalıdır,en azı 1 rəqəm və böyük hərifdən istifadə olunmalıdır")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Bu xana doldurulmalıdır"), DataType(DataType.Password, ErrorMessage = "Şifrə formatı düzgün deyil"), Compare(nameof(Password), ErrorMessage = "Şifrə təkrarı düzgün deyil")]
        public string CheckPassword { get; set; }
    }
}
