using BusinessObjects.Models;

namespace Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        void Delete(int id);
        IEnumerable<Order> GetAll();
        Order GetOrderById(int id);
        List<Order> Report(DateTime startDate, DateTime endDate);
        void Update(Order order);
        void ManagerUpdate(Order order);
    }
}