using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class OrderDetail
    {
        public int DetailId { get; set; }
        public int? OrderId { get; set; }
        public int? CageId { get; set; }
        public decimal? DetailPrice { get; set; }
        public int? DetailQuantity { get; set; }
        public int? AccessoryId { get; set; }

        public virtual Accessory? Accessory { get; set; }
        public virtual Product? Cage { get; set; }
        public virtual Order? Order { get; set; }
    }
}
