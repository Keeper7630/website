using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Адрес электронной почты")]
        [Required(ErrorMessage = "Требуется адрес электронной почты")]
        public string EmailAddress { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Требуется пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
