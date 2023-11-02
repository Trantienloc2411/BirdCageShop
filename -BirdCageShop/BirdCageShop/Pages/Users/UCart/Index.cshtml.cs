using BusinessObjects.Models;
using Humanizer.Localisation.TimeToClockNotation;
using MessagePack;
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
        public Order order { get; set; }
        public int quantity { get; set; }
        
        public IndexModel()
        {
            _usrRepo = new UserRepository();

        }

        public void OnGet()
        {
            try
            {

                int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
                if (userID == -1)
                {
                    TempData["errorMessage"] = "Đăng nhập để tiếp tục!";
                    RedirectToPage("../Login/Index");
                }
                var cartList = _usrRepo.getListcartByUserID(userID);
                if (cartList.Count != 0)
                {
                    cart = cartList.ToList();
                    order = _usrRepo.getOrderPrice_Cart_ByUserID(userID);
                    
                    Page();
                }
                else
                {
                    cart = new List<OrderDetail>();
                    Page();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = "Đã có lỗi xảy ra. Chúng mình đang khắc phục. Lỗi : " + ex.Message;
                Page();
            }

        }

        public IActionResult OnPostDelete(int productID)
        {
            try
            {
                int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
                if (userID == -1)
                {
                    TempData["errorMessage"] = "Đăng nhập để tiếp tục!";
                    return RedirectToPage("../Login/Index");
                }
                else
                {
                    int result = _usrRepo.DeleteProductInCartByProductID(userID, productID);
                    if (result != 0)
                    {
                        TempData["successMessage"] = "Xoá sản phẩm ra khỏi giỏ hàng của bạn thành công";
                        this.OnGet();
                        return Page();
                    }
                    else
                    {
                        TempData["errorMessage"] = "Xoá thất bại!. Đã có lỗi xảy ra";
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Dự án đang phát triển ! Xin lỗi vì sự bất tiện này! Lỗi: " + ex.Message + ". Hãy liên hệ với quản trị viên";
                return Page();
            }

        }
        public IActionResult OnPostEdit(int productID, int quantity)
        {
            int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
            if (userID == -1)
            {
                TempData["errorMessage"] = "Đăng nhập để tiếp tục!";
                return RedirectToPage("../Login/Index");
            }
            else
            {
                int result = _usrRepo.UpdateProductInCartByProductID(userID,productID,quantity);
                if (result != 0)
                {
                    TempData["successMessage"] = "Cập nhật sản phẩm trong giỏ hàng của bạn thành công";
                    this.OnGet();
                    return Page();
                }
                else
                {
                    TempData["errorMessage"] = "Cập nhật thất bại!. Đã có lỗi xảy ra";
                    return Page();
                }
            }
        }
    }
}
