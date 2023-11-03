using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Repository;

namespace BirdCageShop.Pages.Users
{

    public class AccessoryDetailModel : PageModel
    {
        private readonly IProductRepository _proRepo;
        private readonly IUserRepository _userRepo;
        private readonly ICartRepository _cartRepo;
        public AccessoryDetailModel()
        {
            _proRepo = new ProductRepository();
            _userRepo = new UserRepository();
            _cartRepo = new CartRepository();   
        }
        public static int accessoryID { get; set; }
        public Accessory accessory { get; set; }
        public Tuple<int, int> getFeedbackStatic { get; set; }
        public List<Product> getPopularList { get; set; }
        public string ErrorMessage { get; set; }
        public IActionResult OnGet(int accessoryId)
        {
            try
            {
                accessoryID = accessoryId;
                accessory = new Accessory();
                accessory = _proRepo.getDetailAccessoryByID(accessoryID);
                getFeedbackStatic = _proRepo.getFeedback(accessoryID);
                getPopularList = _proRepo.getListProductTrendingForUser();
                if (accessory == null)
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
                    int result = _cartRepo.addProductToCart(accessoryID, 1,1);
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
