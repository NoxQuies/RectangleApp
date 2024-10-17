using System.ComponentModel.DataAnnotations;

namespace RectangleDrawer.Models
{
    public class RectangleModel
    {
        [Required]
        [Range(1, 1000, ErrorMessage = "Width must be between 1 and 1000 pixels.")]
        public int Width { get; set; }

        [Required]
        [Range(1, 1000, ErrorMessage = "Height must be between 1 and 1000 pixels.")]
        public int Height { get; set; }

        [Required]
        [RegularExpression("#[0-9a-fA-F]{6}", ErrorMessage = "Color must be in hex format, e.g., #FF5733.")]
        public string FillColor { get; set; }
    }
}