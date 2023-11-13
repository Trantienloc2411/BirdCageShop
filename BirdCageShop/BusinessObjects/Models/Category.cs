namespace BusinessObjects.Models
{
    public partial class Category
    {
        public Category()
        {
            Accessories = new HashSet<Accessory>();
            Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
