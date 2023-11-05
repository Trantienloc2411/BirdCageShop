using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class FeedbackModel : PageModel
    {
        private readonly IFeedbackRepository _fbRepo;
        private readonly IOrderDetailRepository _odRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IProductRepository productRepository;
        public Feedback fb;
        public Product product;
        public List<OrderDetail> orders;
        public decimal OrderPrice { get; set; }
        public FeedbackModel() 
        {
            _fbRepo = new FeedbackRepository();
            fb = new Feedback();
            _odRepo = new OrderDetailRepository();
            orders = new List<OrderDetail>();
            _orderRepo = new OrderRepository();
            productRepository = new ProductRepository();    
        }
        public void OnGet(int orderID)
        {
            var order = _odRepo.getOrderDetailByOrderID(orderID).ToList();
            orders = order.ToList();
            OrderPrice = (decimal)_orderRepo.GetOrderById(orderID).OrderPrice;
            fb.OrderId = orderID;
            
        }

        public Product getProductNameByProductID(int productID)
        {
            return productRepository.GetProductById(productID);
        }
        public Accessory getAccessoryNameByAccessoryID(int accessoryID)
        {
            return productRepository.getDetailAccessoryByID(accessoryID);
        }
    }
}
