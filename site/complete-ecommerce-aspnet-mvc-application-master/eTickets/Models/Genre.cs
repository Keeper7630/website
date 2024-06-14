using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Genre:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Фото")]
        [Required(ErrorMessage = "Требуется фото")]
        public string ProfilePictureURL { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Требуется ввести имя")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Имя должно содержать от 3 до 50 символов")]
        public string FullName { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Требуется ввести описание")]
        public string Bio { get; set; }

        //Relationships
        public List<Town> Towns { get; set; }
    }
}
