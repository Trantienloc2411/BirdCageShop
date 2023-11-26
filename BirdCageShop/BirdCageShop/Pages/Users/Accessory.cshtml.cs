using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class AccessoryModel : PageModel
    {
        /// <summary>
        /// OnGet View List of Accessory
        /// </summary>
        /// 


        private readonly IProductRepository _proRepos;
        private readonly IUserRepository _userRepo;
        private readonly ICartRepository _cartRepo;
        private readonly IAccessoryRepository _accessoryRepo;
        [BindProperty(SupportsGet = true)]



        public int pageNo { get; set; } = 1; //PageNo
        public int totalProduct { get; set; } //Count
        public int pageSize { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SortBy { get; set; }


        public static int productID { get; set; }
        public List<Accessory> Data { get; set; }
        public AccessoryModel()
        {
            _proRepos = new ProductRepository();
            _userRepo = new UserRepository();
            _cartRepo = new CartRepository();
            _accessoryRepo = new AccessoryRepository();

        }
        public int pOpt0 { get; set; }
        public int pOpt1 { get; set; }
        public int pOpt2 { get; set; }
        public int pOpt3 { get; set; }
        public int pOpt4 { get; set; }
        public IList<Accessory> pagedProducts { get; set; } //Product
        public List<Accessory> accessories { get; set; }
        public void OnGet(int p = 1, int s = 6)
        {
            pOpt0 = _proRepos.FillterProduct(0).Count();
            pOpt1 = _proRepos.FillterProduct(1).Count();
            pOpt2 = _proRepos.FillterProduct(2).Count();
            pOpt3 = _proRepos.FillterProduct(3).Count();
            pOpt4 = _proRepos.FillterProduct(4).Count();
            try
            {
                accessories = _proRepos.GetAccessories();
                if (accessories != null)
                {
                    if (!string.IsNullOrEmpty(SortBy))
                    {
                        switch (SortBy)
                        {
                            case "Quantity":
                                pagedProducts = _proRepos.getAccessoryPages(p, s).OrderByDescending(p => p.AccessoryQuantity).ToList();
                                break;
                            case "Price":
                                pagedProducts = _proRepos.getAccessoryPages(p, s).OrderByDescending(p => p.AccessoryPrice).ToList();
                                break;
                            default:
                                pagedProducts = _proRepos.getAccessoryPages(p, s);
                                break;
                        }
                    }
                    else
                    {
                        pagedProducts = _proRepos.getAccessoryPages(p, s);
                    }
                }

                totalProduct = accessories.Count;
                pageSize = s;
                pageNo = p;
                Page();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }
        public IActionResult OnPost(int accessoryID)
        {
            pOpt0 = _proRepos.FillterProduct(0).Count();
            pOpt1 = _proRepos.FillterProduct(1).Count();
            pOpt2 = _proRepos.FillterProduct(2).Count();
            pOpt3 = _proRepos.FillterProduct(3).Count();
            pOpt4 = _proRepos.FillterProduct(4).Count();
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

                TempData["errorMessage"] = "Somthing unexpected happend!" + ex.Message; return Page();
            }

        }
        public void OnPostSearch(string productName)
        {
            pOpt0 = _proRepos.FillterProduct(0).Count();
            pOpt1 = _proRepos.FillterProduct(1).Count();
            pOpt2 = _proRepos.FillterProduct(2).Count();
            pOpt3 = _proRepos.FillterProduct(3).Count();
            pOpt4 = _proRepos.FillterProduct(4).Count();
            pagedProducts = _proRepos.GetAccessoryByName(productName);
            if (pagedProducts == null)
            {
                OnGet();
            }
        }
        public void OnPostFilterPrice()
        {
            pOpt0 = _proRepos.FillterProduct(0).Count();
            pOpt1 = _proRepos.FillterProduct(1).Count();
            pOpt2 = _proRepos.FillterProduct(2).Count();
            pOpt3 = _proRepos.FillterProduct(3).Count();
            pOpt4 = _proRepos.FillterProduct(4).Count();
            int opt = int.Parse(Request.Form["priceRange"]);
            var list = _accessoryRepo.FillterProduct(opt);
            if (list == null)
            {
                OnGet();
            }
            else
            {
                pagedProducts = list;
                Page();
            }
        }

    }
}
