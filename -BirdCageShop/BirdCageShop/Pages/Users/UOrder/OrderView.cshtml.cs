using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users.UOrder
{
    public class OrderViewModel : PageModel
    {
        private IOrderRepository _orderRepo;
        private IOrderDetailRepository _orderDetailRepo;
        public List<Order> order {  get; set; }
        public int countOrderDetail { get; set; }
        public OrderViewModel()
        {
            _orderRepo = new OrderRepository();
            _orderDetailRepo = new OrderDetailRepository();
        }
        public IActionResult OnGet()
        {
            int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
            if (userID == -1)
            {
                return RedirectToPage("./Error");

            }
            else
            {
                var orderList = _orderRepo.getOrderByUserID(userID);
                if (orderList != null)
                {
                    order = orderList.ToList();
                }
                else
                {
                    order = new List<Order>();
                }
                return Page();
            }
        }

        public int countProductInOrder(int orderID)
        {
            return _orderDetailRepo.getQuantityProductByOrderID(orderID);
        }

        //public IActionResult OnPostDelete(int productID)
        //{

        //}
    }
}
