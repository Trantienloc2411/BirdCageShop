using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly OrderDetailDAO _dao;

        public OrderDetailRepository()
        {
            _dao = new OrderDetailDAO();
        }
        public IEnumerable<OrderDetail> GetAll() => _dao.GetAll();
        public List<Accessory> GetAccessories() => _dao.GetAccessories();
        public List<Order> GetOrders() => _dao.GetOrders();
        public List<Product> GetProducts() => _dao.GetProducts();
    }
}
