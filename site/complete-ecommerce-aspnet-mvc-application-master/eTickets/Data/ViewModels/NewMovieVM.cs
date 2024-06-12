using eTickets.Data;
using eTickets.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Models
{
    public class NewTownVM
    {
        public int Id { get; set; }

        [Display(Name = "Town name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Town description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Town poster URL")]
        [Required(ErrorMessage = "Town poster URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Town start date")]
        [Required(ErrorMessage = "Start date is required")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Town end date")]
        [Required(ErrorMessage = "End date is required")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Town category is required")]
        public TownCategory TownCategory { get; set; }

        //Relationships
        [Display(Name = "Select member(s)")]
        [Required(ErrorMessage = "Town member(s) is required")]
        public List<int> MemberIds { get; set; }

        [Display(Name = "Select a event")]
        [Required(ErrorMessage = "Town event is required")]
        public int EventId { get; set; }

        [Display(Name = "Select a genre")]
        [Required(ErrorMessage = "Town genre is required")]
        public int GenreId { get; set; }
    }
}
