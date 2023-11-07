using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CategoryRepository _cateRepo;
        private readonly ProductRepository _proRepo;
        private readonly IDiscountRepository _discountRepos;
        private readonly ICartRepository _cartRepo;
        public string ErrorMessage { get; set; }

        public IndexModel()
        {
            _cateRepo = new CategoryRepository();
            _proRepo = new ProductRepository();
            _discountRepos = new DiscountRepository();
            _cartRepo = new CartRepository();
        }

        public IList<BusinessObjects.Models.Category> Categories { get; set; }
        public IList<BusinessObjects.Models.Product> Products { get; set; }
        public IActionResult OnGet()
        {
            _discountRepos.AutoUpdateDiscount(); // this is function auto update account after load Index Page
            Categories = _cateRepo.GetAll().ToList();
            Products = _proRepo.getListProductTrendingForUser().ToList();
            
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
        public IActionResult OnPost(int productID)
        {
            try
            {
                if (HttpContext.Session.GetInt32("userID") == null)
                {
                    TempData["errorMessage"] = "Hãy đăng nhập trước khi thêm vào giỏ của bạn nhé. Mình chuyển đến trang đăng nhập giúp bạn rồi nè";
                    return RedirectToPage("/Login/Index");
                }
                else
                {
                    int userID = (int)HttpContext.Session.GetInt32("userID");
                    int result = _cartRepo.addProductToCart(productID, 1, 0);
                    if (result == 0)
                    {
                        TempData["errorMessage"] = "Có vẻ điều gì đó đã xảy ra. Không thể thêm vào giỏ hàng";
                        return RedirectToPage("/Users/Shop");
                    }
                    else
                    {
                        TempData["successMessage"] = "Thêm vào giỏ hàng thành công";
                        return RedirectToPage("/Users/Shop");
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Somthing unexpected happend!" + ex.Message; return RedirectToPage("./Error");
            }

        }
    }
}