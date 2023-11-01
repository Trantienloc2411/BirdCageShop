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
                return RedirectToPage("../Error");
            }
        }




        public IActionResult OnPost(int productID)
            {
                try
                {
                    if (HttpContext.Session.GetInt32("userID") == null)
                    {
                        TempData["errorMessage"] = "Hãy đăng nhập trước khi thêm vào giỏ của bạn nhé. Mình chuyển đến trang đăng nhập giúp bạn rồi nè";
                        return RedirectToPage("./Login");
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

/*
 * 
 * 
 public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public int CurrentPage { get; set; } = 1;
    public int Count { get; set; }
    public int PageSize { get; set; } = 10;
    public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
    public List<Product> Data { get; set; }

    public async Task OnGetAsync()
    {
        Count = await _db.Products.CountAsync();

        var items = await _db.Products
                             .Skip((CurrentPage - 1) * PageSize)
                             .Take(PageSize)
                             .ToListAsync();

        Data = items;
    }
}
*/