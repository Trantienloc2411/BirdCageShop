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

        public IndexModel()
        {
           _cateRepo = new CategoryRepository();
            _proRepo = new ProductRepository();
        }

        public IList<BusinessObjects.Models.Category> Categories { get; set; }
        public IList<BusinessObjects.Models.Product> Products { get; set; } 
        public IActionResult OnGet()
        {
            Categories = _cateRepo.GetAll().ToList();
            Products = _proRepo.getProductListForUser().ToList();
            return Page();
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}