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
        public int OrderID { get; set; }
        public Product product;
        public List<OrderDetail> orders;
        public decimal OrderPrice { get; set; }

        [BindProperty]
        public Feedback feedback { get; set; }

        public FeedbackModel() 
        {
            _fbRepo = new FeedbackRepository();
            feedback = new Feedback();
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
            OrderID = orderID;
            feedback.OrderId = orderID;
            feedback = _fbRepo.GetFeedbackByOrderID((int)feedback.OrderId);
        }
        public void OnPost(int orderID)
        {
            if(orderID != null)
            {
                if (_fbRepo.isFeedbackExistedByOrderID(orderID) == false)
                {
                    feedback.OrderId = orderID;
                    feedback.UserId = (int)HttpContext.Session.GetInt32("userID");
                    _fbRepo.Add(feedback);
                    TempData["successMessage"] = "Phản hồi thành công! Cảm ơn bạn!";
                    OnGet(orderID);
                    Page();
                }
                else
                {
                    TempData["errorMessage"] = "Phản hồi thất bại! Không thể sửa phản hồi!";
                    OnGet(orderID);
                    Page();
                }

            }
            else
            {
                TempData["errorMessage"] = "Hành động thất bại";
                OnGet(orderID);
                Page();
            }

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
