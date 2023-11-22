using BusinessObjects.Models;

namespace Repository
{
    public interface IOrderRepository
    {
        void Add(Order order);
        int AddReturnOrderID(Order order);
        void Delete(int id);
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetAllCancel();
        IEnumerable<Order> GetAllDelivered();
        IEnumerable<Order> GetAllDelivering();
        IEnumerable<Order> GetAllPending();
        Order GetOrderById(int id);
        Order getOrderByOrderID(int orderID);
        List<Order> getOrderByUserID(int userID);
        List<Order> getOrderCancelPages(int pageIndex, int pageSize);
        List<Order> getOrderDeliveredPages(int pageIndex, int pageSize);
        List<Order> getOrderDeliveringPages(int pageIndex, int pageSize);
        List<Order> getOrderPendingPages(int pageIndex, int pageSize);
        int getTotalOrderCancelPages();
        int getTotalOrderDeliveredPages();
        int getTotalOrderDeliveringPages();
        int getTotalOrderPendingPages();
        void ManagerUpdate(Order order);
        List<Order> orderListIncludeOrderDetail(int userID);
        int placeOrderByOrderID(int orderID);
        List<Order> Report(DateTime startDate, DateTime endDate);
        void Update(Order order);
    }
}