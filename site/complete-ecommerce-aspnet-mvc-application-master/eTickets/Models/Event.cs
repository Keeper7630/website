using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class Event:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Лого мероприятия")]
        [Required(ErrorMessage = "Требуется лого мероприятия")]
        public string Logo { get; set; }

        [Display(Name = "Название мероприятия")]
        [Required(ErrorMessage = "Требуется название мероприятия")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        [Required(ErrorMessage = "Требуется описание мероприятия")]
        public string Description { get; set; }

        //Relationships
        public List<Town> Towns { get; set; }
    }
}
