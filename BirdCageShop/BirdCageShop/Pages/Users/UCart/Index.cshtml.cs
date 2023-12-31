﻿using BusinessObjects.Models;
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
        private readonly ICartRepository _cartRepo;
        private readonly IOrderDetailRepository _odRepo;
        public decimal? totalCart { get; set; } = 0;
        public List<CartItem> cart { get; set; }
        public List<CartItem> cartItems { get; set; }
        
        public Order order { get; set; }
        public int quantity { get; set; }
        
        public IndexModel()
        {
            _usrRepo = new UserRepository();
            _cartRepo = new CartRepository();
            _odRepo = new OrderDetailRepository();

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
                _cartRepo.showCustomizeUserCageInCart(userID);
                var cartList = _cartRepo.showCart();
                if (cartList.Count != 0)
                {
                    cart = cartList.ToList();
                    order = _usrRepo.getOrderPrice_Cart_ByUserID(userID);
                    Page();
                }
                else
                {
                    cart = new List<CartItem>();
                    Page();
                }
            }
            catch (Exception ex)
            {

                TempData["errorMessage"] = "Đã có lỗi xảy ra. Chúng mình đang khắc phục. Lỗi : " + ex.Message;
                Page();
            }

        }

        public IActionResult OnPostDelete(int productID, int type)
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
                    int result = _cartRepo.deleteProductfromCart(productID, type);
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
                TempData["errorMessage"] = "Website đang phát triển ! Xin lỗi vì sự bất tiện này! Lỗi: " + ex.Message + ". \nHãy liên hệ với quản trị viên";
                return Page();
            }

        }
        public void OnPostUpdate(int productID, int quantity, int type)
        {

            int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
            if (userID == -1)
            {
                TempData["errorMessage"] = "Đăng nhập để tiếp tục!";
                     RedirectToPage("../Login/Index");
            }
            else if (_odRepo.isProductAvailble(quantity,productID,type) == true)
            {
                _cartRepo.updateQuantity(productID, quantity,type);
                OnGet();
                Page();
            }
            else
            {
                TempData["errorMessage"] = "Sản phẩm bạn vừa cập nhật không đủ số lượng ở cửa hàng";
                OnGet();
            }
            Page();
        }
    }
}
