using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Требуется имя")]
        public string FullName { get; set; }

        [Display(Name = "Адрес электронной почты")]
        [Required(ErrorMessage = "Требуется адрес электронной почты")]
        public string EmailAddress { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Требуется пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Требуется подтверждение пароля")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}
