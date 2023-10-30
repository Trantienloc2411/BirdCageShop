using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users.UCart
{
    public class IndexModel : PageModel
    {
        public string ErrorMessage {  get; set; }
        private readonly IUserRepository _usrRepo;
        public decimal? totalCart { get; set; } = 0;
        public List<OrderDetail> cart { get; set; }
        public List<CartItem> cartItems { get; set; }
        public IndexModel()
        {
            _usrRepo = new UserRepository();

        }

        public IActionResult OnGet()
        {
            try
            {
                int userID = (int)HttpContext.Session.GetInt32("userID");
                var cartList = _usrRepo.getListcartByUserID(userID);
                if (cartList != null)
                {
                    cart = cartList.ToList();
                    return Page();
                }
                else
                {
                    cart = new List<OrderDetail>();
                    return Page();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = "Đã có lỗi xảy ra. Chúng mình đang khắc phục. Lỗi : " + ex.Message;
                return Page();
            }

        }
    }
}
