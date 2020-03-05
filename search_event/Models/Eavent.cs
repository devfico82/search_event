using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace search_event.Models
{
    public class Eavent
    {
        public int EaventID { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę akcji.")]
        [Display(Name = "Nazwa")]
        public string Name { get; set; }

        public string PhotoPath { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Proszę określić kategorię.")]
        [Display(Name = "Kategoria")]
        public string Category { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }
}