using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Member:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Фото профиля")]
        [Required(ErrorMessage = "Требуется фото профиля")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Требуется имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 50 символов")]
        public string FullName { get; set; }

        [Display(Name = "Биография")]
        [Required(ErrorMessage = "Требуется биография")]
        public string Bio { get; set; }

        //Relationships
        public List<Member_Town> Members_Towns { get; set; }
    }
}
