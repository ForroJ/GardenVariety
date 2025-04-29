using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GardenVariety.Models
{
    public class Garden
    {
        public int GardenId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The Produce Name cannot exceed 100 characters.")]
        [Display(Name = "Produce Name")]
        public string Name { get; set; } = string.Empty;

        [EnumDataType(typeof(ProduceType))]
        public ProduceType? Type { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Count must be a non-negative number.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Planting Date")]
        public DateTime PlantingDate { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        [Display(Name = "Additional Notes")]
        public string? Notes { get; set; } = string.Empty;
    }

    public enum ProduceType
    {
        Fruit,
        Vegetable
    }
}
