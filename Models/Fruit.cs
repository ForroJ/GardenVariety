using System.ComponentModel.DataAnnotations;

namespace GardenVariety.Models
{
    public class Fruit
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Name cannot exceed 100 characters.")]
        [Display(Name = "Fruit Name")]
        public string Name { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Fruit count must be a non-negative number.")]
        [Display(Name = "Quantity")]
        public int Fruitcount { get; set; }

        [Display(Name = "Harvested")]
        public bool IsHarvested { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Planting Date")]
        public DateTime PlantingDate { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [Display(Name = "Additional Notes")]
        public string Notes { get; set; } = string.Empty;
    }
}
