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

        OrderDetail GetOrderDetailById(int detailId);
        void Delete(int detailId);
        int AddOrderDetail(OrderDetail detail);
        bool isProductAvailble(int quantity, int productID, int type);
    }
}