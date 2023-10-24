using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class OrderDetailDAO
    {
        private readonly CageShopUni_alaContext _db;

        public OrderDetailDAO()
        {
            _db = new CageShopUni_alaContext();
        }
        public IEnumerable<OrderDetail> GetAll()
        {
            return _db.OrderDetails.ToList();
        }
        public List<Accessory> GetAccessories()
        {
            return _db.Accessories.ToList();
        }
        public List<Order> GetOrders()
        {
            return _db.Orders.ToList();
        }
        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }
    }
}
