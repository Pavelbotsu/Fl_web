using System.ComponentModel.DataAnnotations;

namespace Fl_web.Models
{
    public class OrdersModel
    {
        [Key]
       public int OrderId { get; set; }  // Primary key
        
        public int CustomerId { get; set; }  // Consider linking to a Customer model if needed

        public DateTime OrderDate { get; set; }
        public int TotalAmount { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string ShippingAddress { get; set; } = string.Empty;

        // Navigation properties
        public virtual ICollection<OrderDetailsModel> OrderDetails { get; set; } = new List<OrderDetailsModel>();
        public virtual PaymentModel? Payment { get; set; }


    }
}
