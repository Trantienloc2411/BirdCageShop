using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class OrderDetailModel : PageModel
    {
        private IOrderDetailRepository _odrepo;
        private IOrderRepository _oRepo;
        private IProductRepository _productRepo;
        private IAccessoryRepository _accessoryRepo;
        public Order order;
        public List<OrderDetail> orderDetail;
        public OrderDetailModel()
        {
            _odrepo = new OrderDetailRepository();
            _oRepo = new OrderRepository();
            order = new Order();
            _productRepo = new ProductRepository();
            _accessoryRepo = new AccessoryRepository();

        }
        public IActionResult OnGet(int orderID)
        {
            order = _oRepo.GetOrderById(orderID);
            var odList = _odrepo.getOrderDetailByOrderID(orderID);
            orderDetail = odList.ToList();
            return Page();
        }

        public Product getInformationProduct(int productID)
        {
            var product = _productRepo.GetProduct(productID);
            return product;
        }
        public Accessory getInformationAccessory(int accessoryID) 
        {
            var acc = _accessoryRepo.GetAccessoryById(accessoryID);
            return acc;
        }
    }
}
