using System.ComponentModel.DataAnnotations;

namespace Fl_web.Models
{
    public class PaymentModel
    {
        [Key]
        public int PaymentId { get; set; }  // Primary key
        
        public int OrderId { get; set; }    // Foreign key to Order

        public string PaymentMethod { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public DateTime? PaymentDate { get; set; }

        // Navigation property to the order
        public virtual OrdersModel Order { get; set; } = null!;

    }
}
