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
    public class NewMovieVM
    {
        public int Id { get; set; }

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Требуется ввести город")]
        public string Name { get; set; }

        [Display(Name = "Адрес")]
        [Required(ErrorMessage = "Требуется ввести адрес")]
        public string Description { get; set; }

        [Display(Name = "Цена в Р")]
        [Required(ErrorMessage = "Требуется ввести цену")]
        public double Price { get; set; }

        [Display(Name = "URL картинки")]
        [Required(ErrorMessage = "Требуется ввести URL")]
        public string ImageURL { get; set; }

        [Display(Name = "Дата начала")]
        [Required(ErrorMessage = "Требуется ввести дату")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Время начала")]
        [Required(ErrorMessage = "Требуется ввести время")]
        public DateTime EndDate { get; set; }

        [Display(Name = "Возрастное ограничение")]
        [Required(ErrorMessage = "Требуется ввести ограничение")]
        public MovieCategory MovieCategory { get; set; }

        //Relationships
        [Display(Name = "Выбор участников")]
        [Required(ErrorMessage = "Требуется выбрать участников")]
        public List<int> ActorIds { get; set; }

        [Display(Name = "Тип мероприятия")]
        [Required(ErrorMessage = "Требуется указать тип")]
        public int CinemaId { get; set; }

        [Display(Name = "Жанр")]
        [Required(ErrorMessage = "Требуется указать жанр")]
        public int ProducerId { get; set; }
    }
}
