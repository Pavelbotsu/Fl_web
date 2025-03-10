using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Fl_web.Models
{
   
    public class CategoryModel

    {

        [Key]   
        public int CategoryId { get; set; }  // Primary key

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        // Navigation property for products in this category
        public virtual ICollection<ProductModel> Products { get; set; } = new List<ProductModel>();
    }

}
