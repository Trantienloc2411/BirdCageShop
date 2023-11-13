using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class PaymentMethod
    {
        public PaymentMethod()
        {
            Orders = new HashSet<Order>();
        }

        public int PaymentId { get; set; }
        public string? PaymentName { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
