using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Fl_web.Models
{
    public class ProductModel
    {
        [Key]
        public int ProductId { get; set; }  // Primary key

        
        public int CategoryId { get; set; } // Foreign key to Category

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public int Price { get; set; }

        [Required]
        public int Stock { get; set; }

        // Navigation property for multiple images
        public virtual ICollection<ProductImageModel> Images { get; set; } = new List<ProductImageModel>();

        // Navigation property for category
        public virtual CategoryModel Category { get; set; } = null!;
    }
}
