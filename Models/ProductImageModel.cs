using System.ComponentModel.DataAnnotations;

namespace Fl_web.Models
{
    public class ProductImageModel
    {
        [Key]
        public int ImageId { get; set; }  // Primary key
       
        public int ProductId { get; set; }  // Foreign key to Product

        public string? ImageUrl { get; set; }

        // Navigation property back to the product
        public virtual ProductModel Product { get; set; } = null!;
        
    }
}
