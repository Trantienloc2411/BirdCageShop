using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MProduct
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _proRepo;

        public CreateModel(IProductRepository productRepository)
        {
            _proRepo = productRepository;
        }


        [BindProperty]
        public BusinessObjects.Models.Product Product { get; set; }

        public IActionResult OnGet()
        {
            // Ensure Product is instantiated
            Product = new BusinessObjects.Models.Product();

            var listCategories = _proRepo.GetCategories();
            var listDiscounts = _proRepo.GetDiscounts();
            TempData["CategoryId"] = new SelectList(listCategories, "CategoryId", "CategoryName", Product.CategoryId);
            TempData["DiscountId"] = new SelectList(listDiscounts, "DiscountId", "DiscountName", Product.DiscountId);
            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _proRepo.Add(Product);

            return RedirectToPage("./Index");
        }
    }
}
