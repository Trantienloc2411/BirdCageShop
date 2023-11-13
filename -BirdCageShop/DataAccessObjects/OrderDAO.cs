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
        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.ToList();
        }

        private bool ValidateProduct(Product product)
        {
            if (string.IsNullOrEmpty(product.CageName))
            {
                throw new ArgumentException("Cage Name is required.", nameof(product.CageName));
            }

            if (product.CategoryId <= 0)
            {
                throw new ArgumentException("Category is required.", nameof(product.CategoryId));
            }

            if (product.Quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than 0.", nameof(product.Quantity));
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than 0.", nameof(product.Price));
            }
            if (product.DiscountId <= 0)
            {
                throw new ArgumentException("Discount is required.", nameof(product.DiscountId));
            }
            if (string.IsNullOrEmpty(product.Material))
            {
                throw new ArgumentException("Material is required.", nameof(product.Material));
            }
            if (string.IsNullOrEmpty(product.Size))
            {
                throw new ArgumentException("Size must be greater than 0.", nameof(product.Size));
            }
            if (product.Bar <= 0)
            {
                throw new ArgumentException("Bar is required.", nameof(product.Bar));
            }
            if (string.IsNullOrEmpty(product.Description))
            {
                throw new ArgumentException("Description is required.", nameof(product.Description));
            }
            if (product.CageStatus <= 0)
            {
                throw new ArgumentException("CageStatus is required.", nameof(product.CageStatus));
            }

            // Add validations for other required fields

            return true;
        }
    }
}
