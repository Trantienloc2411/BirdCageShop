using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class CheckoutCustomizeModel : PageModel
    {
        
        public IUserRepository  _userRepo;
        public ICartRepository _cartRepo;
        public IOrderRepository _orderRepo;
        public IOrderDetailRepository _orderDetailRepo;

        [BindProperty(SupportsGet = true)]
        public decimal OrderPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal ExpMachining { get; set; }

        [BindProperty(SupportsGet = true)]
        public int Est { get; set; }


        public User user { get; set; }
        public string ErrorMessage { get; set; }
        public CheckoutCustomizeModel()
        {
            _userRepo = new UserRepository();
            _cartRepo = new CartRepository();
            _orderRepo = new OrderRepository();
            _orderDetailRepo = new OrderDetailRepository();
        }
        public List<CartItem> cartItems { get; set; }
        /// <summary>
        /// Load cart to order  
        /// </summary>
        public IActionResult OnGet(decimal orderPrice, decimal expMachining, int est)
        {
            int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
            if (HttpContext.Session.Id == null)
            {
                TempData["errorMessage"] = "Hãy xác thực để xem thông tin của mình nhé";
                return RedirectToPage("../Login/Index");
            }
            user = _userRepo.GetUserById(userID);
            cartItems = _cartRepo.showCart();
            if(cartItems == null || cartItems.Count == 0)
            {
                TempData["errorMessage"] = "Trong giỏ hàng của bạn đang trống! Hãy lấp đầy đi nào";
                return RedirectToPage("../Index");
                
            }
            else
            {
                OrderPrice = orderPrice;
                ExpMachining = expMachining;
                Est = est;
                return Page();
            }
        }

        /// <summary>
        /// Place Order 
        /// </summary>
        public IActionResult OnPost(string OrderName, string OrderEmail, string OrderPhone, string OrderAddress, string Note, decimal OrderTotal)
        {
            int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
            Order o = new Order();
            o.OrderName = OrderName;
            o.OrderPhone = OrderPhone;  
            o.OrderPrice = OrderTotal;
            o.OrderAdress = OrderAddress;
            ///use utc+7
            DateTime utcNow = DateTime.UtcNow;
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
            DateTime localTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, timeZone);
            o.OrderDate = localTime;
            o.OrderStatus = "Pending";
            o.PaymentId = 1;
            o.UserId = userID;
            o.OrderType = 1;
            o.OrderEst = localTime.AddDays(Est).ToString();
            if(Note == null)
            {
                o.Note = "";
            }
            else
            {
                o.Note = Note;
            }

            int orderID = _orderRepo.AddReturnOrderID(o);
            cartItems = _cartRepo.showCart();
            
            foreach(var item in cartItems)
            {
                if (item.type == 0)
                {

                    OrderDetail od = new OrderDetail();
                    od.OrderId = orderID;
                    od.CageId = item.Id;
                    od.DetailPrice = item.DetailPrice;
                    od.DetailQuantity = item.DetailQuantity;
                    int isCompleted = _orderDetailRepo.AddOrderDetail(od);
                    if (isCompleted == 0) break;

                }
                else if (item.type == 1)
                {
                    OrderDetail od = new OrderDetail();
                    od.OrderId = orderID;
                    od.AccessoryId = item.Id;
                    od.DetailPrice = item.DetailPrice;
                    od.DetailQuantity = item.DetailQuantity;
                    int isCompleted = _orderDetailRepo.AddOrderDetail(od);
                    if (isCompleted == 0) break;
                }
            }
            TempData["successMessage"] = "Đặt hàng thành công";
            _cartRepo.clearCart();
            return RedirectToPage("../Index");
        }

    }
}
