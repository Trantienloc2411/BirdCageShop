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
        public List<OrderDetail> getOrderDetailByOrderID(int orderID)
        {
            return _db.OrderDetails.Where(o => o.OrderId == orderID).ToList();
        }
        public int getQuantityProductByOrderID(int orderID)
        {
            return _db.OrderDetails.Where(o => o.OrderId == orderID).Count();
        }
    }
}
