using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
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
        private readonly IFeedbackRepository _feedbackRepo;
        private readonly ICartRepository _cartRepo;
        public ProductDetailModel()
        {
            _proRepo = new ProductRepository();
            _userRepo = new UserRepository();
            _feedbackRepo = new FeedbackRepository();
            _cartRepo = new CartRepository();
        }
        public int Id { get; set; }
        public static int productID { get; set; }
        public Product product { get; set; }
        public Tuple<int, int> getFeedbackStatic { get; set; }
        public List<Product> getPopularList { get; set; }
        public List<FeedbackItem> getFeedback { get; set; }
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
                getFeedback = _feedbackRepo.getListFeedbackByProductID(productId);
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

                return RedirectToAction("../Error: ");
            }
        }

        public async Task<IActionResult> OnPostAddAsync()
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
                    int result = _cartRepo.addProductToCart(productID,1,0);
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
        public async Task<IActionResult> OnPostCompareAsync()
        {
            if(productID != 0)
            {
                if(HttpContext.Session.GetInt32("pID1") == 0 || HttpContext.Session.GetInt32("pID1") == null)
                {
                    HttpContext.Session.SetInt32("pID1", productID);
                    TempData["successMessage"] = "Thêm sản phẩm thành công! (1/2)";
                    OnGet(productID);
                    return RedirectToPage("./Shop");
                }
                else if(HttpContext.Session.GetInt32("pID2") == 0 || HttpContext.Session.GetInt32("pID2") == null)
                {
                    HttpContext.Session.SetInt32("pID2", productID);
                    TempData["successMessage"] = "Thêm sản phẩm thành công! (2/2)";
                    OnGet(productID);
                    return RedirectToPage("./Shop");
                } else if(HttpContext.Session.GetInt32("pID1") != 0 && HttpContext.Session.GetInt32("pID2") != 0)
                {
                    TempData["errorMessage"] = "Thêm sản phẩm so sánh thất bại! Danh sách so sánh đã đầy! (2/2)";
                    OnGet(productID);
                    return Page();
                }
                else return RedirectToPage();
            }
            return RedirectToPage();
        }

        
        
    }
}
