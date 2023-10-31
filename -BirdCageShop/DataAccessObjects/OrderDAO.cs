using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class OrderDAO
    {
        private readonly CageShopUni_alaContext _db;

        public OrderDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public Order GetOrderById(int orderId)
        {
            return _db.Orders.FirstOrDefault(o => o.OrderId == orderId);
        }
        public List<Order> Report(DateTime startDate, DateTime endDate)
        {
            return _db.Orders.Where(o => o.OrderDate >= startDate && o.OrderDate <= endDate).OrderByDescending(o => o.OrderPrice).ToList();
        }
        public void Add(Order order)
        {
            _db.Add(order);
            _db.SaveChanges();
        }
        public void Update(Order order)
        {
            var o = GetOrderById(order.OrderId);
            if (o != null)
            {
                o.OrderStatus = order.OrderStatus;
                o.OrderPrice = order.OrderPrice;
                o.OrderDate = order.OrderDate;
                o.OrderAdress = order.OrderAdress;
                o.OrderName = order.OrderName;
                o.OrderPhone = order.OrderPhone;
                o.Note = order.Note;

                _db.SaveChanges();
            }
        }
        public void Delete(int orderId)
        {
            var o = GetOrderById(orderId);
            if (o != null)
            {
                _db.Orders.Remove(o);
                _db.SaveChanges();
            }
        }
        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.ToList();
        }

        public List<Order> getOrderByUserID(int userID)
        {
            return _db.Orders.Where(o => o.OrderStatus != "Cart" && o.UserId == userID).ToList();
        }

    }
}
