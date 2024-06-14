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

        [Display(Name = "Название города")]
        [Required(ErrorMessage = "Требуется имя")]
        public string Name { get; set; }

        [Display(Name = "Описание города")]
        [Required(ErrorMessage = "Требуется описание")]
        public string Description { get; set; }

        [Display(Name = "Цена в рублях")]
        [Required(ErrorMessage = "Требуется цена")]
        public double Price { get; set; }

        [Display(Name = "Изображение города URL")]
        [Required(ErrorMessage = "Требуется URL изображения города")]
        public string ImageURL { get; set; }

        [Display(Name = "Дата начала")]
        [Required(ErrorMessage = "Требуется дата начала")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Время начала")]
        [Required(ErrorMessage = "Требуется время начала")]
        public TimeSpan StartTime { get; set; }

        [Display(Name = "Выберите возрастное ограничение")]
        [Required(ErrorMessage = "Требуется возрастное ограничение")]
        public TownCategory TownCategory { get; set; }

        //Relationships
        [Display(Name = "Выберите участника(ов)")]
        [Required(ErrorMessage = "Требуются участники")]
        public List<int> MemberIds { get; set; }

        [Display(Name = "Выберите мероприятие")]
        [Required(ErrorMessage = "Требуется мероприятие")]
        public int EventId { get; set; }

        [Display(Name = "Выберите жанр")]
        [Required(ErrorMessage = "Требуется жанр")]
        public int GenreId { get; set; }
    }
}
