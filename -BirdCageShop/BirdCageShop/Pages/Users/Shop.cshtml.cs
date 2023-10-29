using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }  = 0;
        private readonly IProductRepository _proRepos;
        private readonly IUserRepository _userRepo;
        public static int productID { get; set; }
        public List<Product> Data { get; set; }
        public IndexModel()
        {
            _proRepos = new ProductRepository();
            _userRepo = new UserRepository();
        }
        public List<BusinessObjects.Models.Product> pagedProducts { get; set; }
        public List<Product> Products { get; set; }
        public IActionResult OnGet()
        {

            try
            {
                int pageNumber = CurrentPage; // Số trang hiện tại
                int pageSize = 6; // Số lượng sản phẩm trên mỗi trang

                Products = _proRepos.getProductListForUser().ToList();
                if (Products != null)
                {
                    pagedProducts = Products
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();
                }
                int totalPages = (int)Math.Floor((int)Products.Count / (double)pageSize);
                TotalPages += totalPages;

                return Page();
            }
            catch (Exception ex)
            {
                return RedirectToPage("../Error");
            }
        }
        public IActionResult OnPost()
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