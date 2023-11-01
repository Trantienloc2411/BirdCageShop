using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDAO _dao;

        public OrderRepository()
        {
            _dao = new OrderDAO();
        }
        public void Add(Order order) => _dao.Add(order);
        public void Delete(int id) => _dao.Delete(id);
        public Order GetOrderById(int id) => _dao.GetOrderById(id);
        public IEnumerable<Order> GetAll() => _dao.GetAll();
        public void Update(Order order) => _dao.Update(order);
        public List<Order> Report(DateTime startDate, DateTime endDate) => _dao.Report(startDate, endDate);
        public void ManagerUpdate(Order order) => _dao.ManagerUpdate(order);
    }
}
