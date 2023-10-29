namespace BusinessObjects.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int CageId { get; set; }
        public string? CageName { get; set; }
        public int? CategoryId { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
        public int? DiscountId { get; set; }
        public byte[]? CageImg { get; set; }
        public string? Material { get; set; }
        public string? Size { get; set; }
        public int? Bar { get; set; }
        public string? Description { get; set; }
        public int? CageStatus { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
