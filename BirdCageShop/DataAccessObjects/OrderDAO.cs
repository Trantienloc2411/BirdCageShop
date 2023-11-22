using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

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
        public int AddReturnOrderID(Order order)
        {
            _db.Orders.Add(order);
            _db.SaveChanges();
            return order.OrderId;
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
        public void ManagerUpdate(Order order)
        {
            var o = GetOrderById(order.OrderId);
            if (o != null)
            {
                o.OrderStatus = order.OrderStatus;
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

        public List<Order> getOrderPendingPages(int pageIndex, int pageSize)
        {
            return _db.Orders.Where(u => u.OrderStatus == "Pending").Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Order> getOrderCancelPages(int pageIndex, int pageSize)
        {
            return _db.Orders.Where(u => u.OrderStatus == "Cancelled").Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Order> getOrderDeliveringPages(int pageIndex, int pageSize)
        {
            return _db.Orders.Where(u => u.OrderStatus == "Delivering").Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Order> getOrderDeliveredPages(int pageIndex, int pageSize)
        {
            return _db.Orders.Where(u => u.OrderStatus == "Delivered").Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }

        public int getTotalOrderPendingPages()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Pending").Count();
        }
        public int getTotalOrderCancelPages()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Cancelled").Count();
        }
        public int getTotalOrderDeliveringPages()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Delivering").Count();
        }
        public int getTotalOrderDeliveredPages()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Delivered").Count();
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.ToList();
        }
        public IEnumerable<Order> GetAllPending()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Pending").OrderByDescending(u => u.OrderId).ToList();
        }
        public IEnumerable<Order> GetAllCancel()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Cancelled").OrderByDescending(u => u.OrderDate).ToList();
        }
        public IEnumerable<Order> GetAllDelivering()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Delivering").OrderByDescending(u => u.OrderDate).ToList();
        }
        public IEnumerable<Order> GetAllDelivered()
        {
            return _db.Orders.Where(u => u.OrderStatus == "Delivered").OrderByDescending(u => u.OrderDate).ToList();
        }

        public List<Order> getOrderByUserID(int userID)
        {
            return _db.Orders.Where(o => o.OrderStatus != "Cart" && o.UserId == userID).ToList();
        }

        public int placeOrderByOrderID(int orderID)
        {
            var order = _db.Orders.FirstOrDefault(o => o.OrderId == orderID && o.OrderStatus == "Cart");
            order.OrderStatus = "Pending";
            return _db.SaveChanges();
        }
        public List<Order> orderListIncludeOrderDetail(int userID)
        {
            return _db.Orders.Include(o => o.OrderDetails).Where(o => o.UserId == userID && o.OrderStatus != "Cart").ToList();
        }

        public Order getOrderByOrderID(int orderID)
        {
            return _db.Orders.FirstOrDefault(o => o.OrderId == orderID);
        }

        //public Tuple<Product,Product> comparisionProduct(Product prod1, Product prd2)
        //{

        //}
    }
}