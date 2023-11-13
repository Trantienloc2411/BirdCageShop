namespace BusinessObjects.Models
{
    public partial class Accessory
    {
        public Accessory()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int AccessoryId { get; set; }
        public string? AccessoryName { get; set; }
        public double? AccessoryPrice { get; set; }
        public string? AccessoryDescription { get; set; }
        public int? AccessoryQuantity { get; set; }
        public int? AccessoryStatus { get; set; }
        public int? CategoryId { get; set; }
        public int? DiscountId { get; set; }
        public string? AccessoryImg { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
