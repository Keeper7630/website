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

        [Display(Name = "Event Logo")]
        [Required(ErrorMessage = "Event logo is required")]
        public string Logo { get; set; }

        [Display(Name = "Event Name")]
        [Required(ErrorMessage = "Event name is required")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Event description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Town> Towns { get; set; }
    }
}
