using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MProduct
{
    public class IndexModel : PageModel
    {
        private readonly ProductRepository _proRepo;

        public IndexModel()
        {
            _proRepo = new ProductRepository();
        }

        public IList<BusinessObjects.Models.Product> Product { get; set; }

        public IActionResult OnGet()
        {
            Product = _proRepo.GetAll().ToList();
            ViewData["CategoryId"] = new SelectList(_proRepo.GetCategories(), "CategoryId", "CategoryId");
            ViewData["DiscountId"] = new SelectList(_proRepo.GetDiscounts(), "DiscountId", "DiscountId");
            return Page();
        }
    }
}

