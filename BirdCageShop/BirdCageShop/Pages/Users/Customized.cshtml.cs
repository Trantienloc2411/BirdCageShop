using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
        public class CustomizedModel : PageModel
        {
            private readonly IProductRepository _proRepos;
            private readonly ICartRepository _cartRepo;

            [BindProperty]
            public int cageType { get; set; }
            [BindProperty]
            public int lidCage { get; set; }
            [BindProperty]
            public int barCageType { get; set; }
            [BindProperty]
            public int barCageCount { get; set; } = 50;
            [BindProperty]
            public int doorCageType { get; set; }
            [BindProperty]
            public int baseCage { get; set; }
            [BindProperty]
            public int orderPrice { get; set; }
            [BindProperty]
            public int expenseMachining { get; set; }

            public CustomizedModel()
            {
                _proRepos = new ProductRepository();
                _cartRepo = new CartRepository();
            }

            public IActionResult OnPost()
            {
                doorCageType = Int32.Parse(Request.Form["doorCage"]);
                string? orderEst = Request.Form["OrderEst"];
                orderPrice = int.Parse(Request.Form["OrderPrice"]);
                expenseMachining = int.Parse(Request.Form["ExpenseMachining"]);

                if (barCageCount <= 50 && barCageCount >= 80)
                {
                    TempData["exMessage"] = "Số nan phải lớn hơn 50 và nhỏ hơn 80 nan"; return Page();
                }
                else if (HttpContext.Session.GetString("userName") == null)
                {
                    TempData["errorMessage"] = "Hãy đăng nhập tài khoản để được trải nghiệm tốt hơn";
                    return RedirectToPage("/Login/Index");
                }

                int result = 0;
                if (_cartRepo.showCart().Count != 0) _cartRepo.clearCart();
                //add cageStyle to cart
                result = _cartRepo.addProductToCart(cageType, 1, 0);
                //add lidCage to cart
                result = _cartRepo.addProductToCart(lidCage, 1, 0);
                //add barCageType and Quantity to cart
                result = _cartRepo.addProductToCart(barCageType, barCageCount, 0);
                //add doorcageType to cart
                result = _cartRepo.addProductToCart(doorCageType, 1, 0);
                //add baseCage (đế của lồng) to cart
                result = _cartRepo.addProductToCart(baseCage, 1, 0);

                if (result == 0)
                {
                    TempData["errorMessage"] = "Đưa vào danh sách giỏ hàng thất bại";
                    return Page();
                }

                return RedirectToPage("./CheckoutCustomize", new { orderPrice = orderPrice, expMachining = expenseMachining, est = orderEst });
            }



        }
    }
