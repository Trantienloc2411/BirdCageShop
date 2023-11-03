using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class OrderDetailDAO
    {
        private readonly CageShopUni_alaContext _db;
        private CartDAO _cartDAO;
        public OrderDetailDAO()
        {
            _db = new CageShopUni_alaContext();
            _cartDAO = new CartDAO();   
        }
        public IEnumerable<OrderDetail> GetAll()
        {
            return _db.OrderDetails.ToList();
        }
        public List<Accessory> GetAccessories()
        {
            return _db.Accessories.ToList();
        }
        public List<Order> GetOrders()
        {
            return _db.Orders.ToList();
        }
        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public List<OrderDetail> getOrderDetailByOrderID(int orderID)
        {
            return _db.OrderDetails.Where(o => o.OrderId == orderID).ToList();
        }
        public int getQuantityProductByOrderID(int orderID)
        {
            return _db.OrderDetails.Where(o => o.OrderId == orderID).Count();
        }
        public OrderDetail GetOrderDetailById(int detailId)
        {
            return _db.OrderDetails.FirstOrDefault(o => o.DetailId == detailId);
        }

        public void Delete(int detailId)
        {
            var o = GetOrderDetailById(detailId);
            if (o != null)
            {
                _db.OrderDetails.Remove(o);
                _db.SaveChanges();
            }
        }
        
        public int AddOrderDetail(OrderDetail detail)
        {
            if(detail != null)
            {
                _db.OrderDetails.Add(detail);
                ///Decrease quantity -1 if place order succesfully
                if (detail.CageId != null)
                {
                    var product = _db.Products.First(p => p.CageId == detail.CageId);
                    product.Quantity--;
                }
                else
                {
                    var product = _db.Accessories.First(a => a.AccessoryId == detail.AccessoryId);
                    product.AccessoryQuantity--;
                }
                return _db.SaveChanges();
            }
            else
            {
                _db.SaveChanges();
                //_cartDAO.clearCart();
                return 0;
            }
        }

        public bool isProductAvailble(int quantity, int productID, int type)
        {
            if(type == 0)
            {
                var product = _db.Products.First(p => p.CageId == productID);
                if (product.Quantity < quantity) return false;
                else return true;
            }
            else
            {
                var product = _db.Accessories.First(a => a.AccessoryId == productID);
                if (product.AccessoryQuantity < quantity) return false;
                else return true;
            }
        }
    }
}
