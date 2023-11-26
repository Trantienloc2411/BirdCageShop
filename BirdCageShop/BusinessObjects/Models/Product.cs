using System.ComponentModel.DataAnnotations;

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
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater than or equal to 0.")]
        public int? Quantity { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Price must be greater than or equal to 0.")]
        public decimal? Price { get; set; }
        public int? DiscountId { get; set; }
        public string? Material { get; set; }
        public string? Size { get; set; }
        [Range(50, 90, ErrorMessage = "Bar must be 50 - 90.")]
        public int? Bar { get; set; }
        public string? Description { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Cage Status must be greater than or equal to 0.")]
        public int? CageStatus { get; set; }
        public string? CageImg { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Discount? Discount { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
