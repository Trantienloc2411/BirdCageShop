using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Accessories = new HashSet<Accessory>();
            Products = new HashSet<Product>();
        }

        public int DiscountId { get; set; }
        public string? DiscountName { get; set; }
        public DateTime? DiscountStart { get; set; }
        public DateTime? DiscountFinish { get; set; }
        public decimal? Discount1 { get; set; }
        public string? DiscountStatus { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
