using BusinessObjects.Models;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        List<Accessory> GetAccessories();
        List<Order> GetOrders();
        List<Product> GetProducts();
        List<OrderDetail> getOrderDetailByOrderID(int orderID);
        int getQuantityProductByOrderID(int orderID);
    }
}