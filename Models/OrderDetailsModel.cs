using System.ComponentModel.DataAnnotations;

namespace Fl_web.Models
{
    public class OrderDetailsModel
    {
        [Key]
        public int OrderDetailId { get; set; }  // Primary key
        
        public int OrderId { get; set; }        // Foreign key to Order
        
        public int ProductId { get; set; }      // Foreign key to Product

        public int Quantity { get; set; }
        public int Price { get; set; }

        // Navigation properties
        public virtual OrdersModel Order { get; set; } = null!;
        public virtual ProductModel Product { get; set; } = null!;

    }
}
