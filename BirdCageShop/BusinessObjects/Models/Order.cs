using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessObjects.Models
{
    public partial class Order
    {
        public Order()
        {
            Feedbacks = new HashSet<Feedback>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? UserId { get; set; }
        public string? OrderStatus { get; set; }
        public decimal? OrderPrice { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        public string? OrderAdress { get; set; }
        public string? OrderName { get; set; }
        public string? OrderPhone { get; set; }
        public int? PaymentId { get; set; }
        public string? Note { get; set; }
        public string? OrderEst { get; set; }
        public int? OrderType { get; set; }
        // if 0 : Order Normal
        // if 1: Order Customize Cage
        public virtual PaymentMethod? Payment { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }   
}
