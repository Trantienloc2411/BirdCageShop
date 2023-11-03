using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Repository;
using System.Drawing.Printing;

namespace BirdCageShop.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _proRepos;
        private readonly IUserRepository _userRepo;
        private readonly ICartRepository _cartRepo;
        [BindProperty(SupportsGet = true)]



        public int pageNo { get; set; } = 1; //PageNo
        public int totalProduct { get; set; } //Count
        public int pageSize { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }


        public static int productID { get; set; }
        public List<Product> Data { get; set; }
        public IndexModel()
        {
            _proRepos = new ProductRepository();
            _userRepo = new UserRepository();
            _cartRepo = new CartRepository();
        }

        public IList<BusinessObjects.Models.Product> pagedProducts { get; set; } //Product
        public List<Product> Products { get; set; }



        public IActionResult OnGet(int p = 1, int s = 6)
        {
            try
            {
                Products = _proRepos.getListProductForUser().ToList();

                if (Products != null)
                {
                    if (!string.IsNullOrEmpty(SortBy))
                    {
                        switch (SortBy)
                        {
                            case "Quantity":
                                pagedProducts = _proRepos.getProductPagesForUser(p, s).OrderByDescending(p => p.Quantity).ToList();
                                break;
                            case "Price":
                                pagedProducts = _proRepos.getProductPagesForUser(p, s).OrderByDescending(p => p.Price).ToList();
                                break;
                            default:
                                pagedProducts = _proRepos.getProductPagesForUser(p, s);
                                break;
                        }
                    }
                    else
                    {
                        pagedProducts = _proRepos.getProductPagesForUser(p, s);
                    }
                    totalProduct = Products.Count();
                }

                pageSize = s;
                pageNo = p;
                return Page();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
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
                        int result = _cartRepo.addProductToCart(productID, 1,0);
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

                    TempData["errorMessage"] = "Somthing unexpected happend!" + ex.Message;
                    return Page();
                }

            }
        public void OnPostSearch(string productName)
        {
            pagedProducts = _proRepos.GetListProductByName(productName);
            if (pagedProducts == null)
            {
                OnGet();
            }
        }


    }
}
