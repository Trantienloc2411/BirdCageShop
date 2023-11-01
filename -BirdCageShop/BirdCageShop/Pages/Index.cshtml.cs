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
        public string ErrorMessage { get; set; }

        public IndexModel()
        {
            _cateRepo = new CategoryRepository();
            _proRepo = new ProductRepository();
            _discountRepos = new DiscountRepository();
        }

        public IList<BusinessObjects.Models.Category> Categories { get; set; }
        public IList<BusinessObjects.Models.Product> Products { get; set; }
        public IActionResult OnGet()
        {
            _discountRepos.AutoUpdateDiscount(); // this is function auto update account after load Index Page
            Categories = _cateRepo.GetAll().ToList();
            Products = _proRepo.getListProductTrendingForUser().ToList();
            TempData["errorMessage"] = "";
            return Page();
        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("../Index");
        }
    }
}