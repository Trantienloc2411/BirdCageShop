using BusinessObjects.Models;

namespace Repository
{
    public interface IOrderDetailRepository
    {
        IEnumerable<OrderDetail> GetAll();
        List<Accessory> GetAccessories();
        List<Order> GetOrders();
        List<Product> GetProducts();
        OrderDetail GetOrderDetailById(int detailId);
        void Delete(int detailId);
    }
}