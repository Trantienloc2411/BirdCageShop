using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MProduct
{
    public class DetailsModel : PageModel
    {
        private readonly IProductRepository _proRepo;

        public DetailsModel(IProductRepository productRepository)
        {
            _proRepo = productRepository;
        }

        public BusinessObjects.Models.Product Product { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _proRepo.GetProductById(id);
            ViewData["CategoryId"] = new SelectList(_proRepo.GetCategories(), "CategoryId", "CategoryId");
            ViewData["DiscountId"] = new SelectList(_proRepo.GetDiscounts(), "DiscountId", "DiscountId");
            if (Product == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
