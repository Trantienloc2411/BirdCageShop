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
        }

        public IList<Accessory> pagedProducts { get; set; } //Product
        public List<Accessory> accessories { get; set; }
        public void OnGet(int p = 1, int s = 6)
        {
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
        //public IActionResult OnPost(int accessoryID)
        //{
        //    try
        //    {
        //        if (HttpContext.Session.GetInt32("userID") == null)
        //        {
        //            TempData["errorMessage"] = "Hãy đăng nhập trước khi thêm vào giỏ của bạn nhé. Mình chuyển đến trang đăng nhập giúp bạn rồi nè";
        //            return RedirectToPage("./Login");
        //        }
        //        else
        //        {
        //            int userID = (int)HttpContext.Session.GetInt32("userID");
        //            int result = _userRepo.AddProductToCart(userID, , 1);
        //            if (result == 0)
        //            {
        //                TempData["errorMessage"] = "Có vẻ điều gì đó đã xảy ra. Không thể thêm vào giỏ hàng";
        //                return RedirectToPage("./Shop");
        //            }
        //            else
        //            {
        //                TempData["successMessage"] = "Thêm vào giỏ hàng thành công";
        //                return RedirectToPage("./Shop");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        TempData["errorMessage"] = "Somthing unexpected happend!" + ex.Message; return RedirectToPage("./Error");
        //    }

        //}
        public void OnPostSearch(string productName)
        {
            pagedProducts = _proRepos.GetAccessoryByName(productName);
            if (pagedProducts == null)
            {
                OnGet();
            }
        }
    }
}
