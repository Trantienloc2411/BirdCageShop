using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Repository;

namespace BirdCageShop.Pages.Users
{

    public class ProductDetailModel : PageModel
    {
        private readonly IProductRepository _proRepo;
        private readonly IUserRepository _userRepo;
        public ProductDetailModel()
        {
            _proRepo = new ProductRepository();
            _userRepo = new UserRepository();
        }
        public static int productID { get; set; }
        public Product product { get; set; }
        public Tuple<int, int> getFeedbackStatic { get; set; }
        public List<Product> getPopularList { get; set; }
        public string ErrorMessage { get; set; }
        public IActionResult OnGet(int productId)
        {
            try
            {
                productID = productId;
                product = new Product();
                product = _proRepo.GetProductById(productId);
                getFeedbackStatic = _proRepo.getFeedback(productId);
                getPopularList = _proRepo.getListProductTrendingForUser();
                if (product == null)
                {
                    return RedirectToAction("../Error");

                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {

                return RedirectToAction("../Error");
            }
        }

        public IActionResult OnPost()
        {
            try
            {
                if (HttpContext.Session.GetInt32("userID") == null)
                {
                    TempData["errorMessage"] = "Hãy đăng nhập trước khi thêm vào giỏ của bạn nhé. Mình chuyển đến trang đăng nhập giúp bạn rồi nè";
                    return RedirectToPage("../Login/Index");
                }
                else
                {
                    int userID = (int)HttpContext.Session.GetInt32("userID");
                    int result = _userRepo.AddProductToCart(userID, productID, 1);
                    if (result == 0)
                    {
                        TempData["errorMessage"] = "Có vẻ điều gì đó đã xảy ra. Không thể thêm vào giỏ hàng";
                        return RedirectToPage("./Shop");
                    }
                    else
                    {
                        TempData["successMessage"] = "Thêm vào giỏ hàng thành công";
                        return RedirectToPage("./Shop");
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
