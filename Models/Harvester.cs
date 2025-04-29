using System;
using System.ComponentModel.DataAnnotations;

namespace GardenVariety.Models
{
    public class Harvester
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Harvest Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "The Garden field is required.")]
        [Display(Name = "Garden")]
        public int GardenId { get; set; }

        public Garden Garden { get; set; } = default!;
    }
}
