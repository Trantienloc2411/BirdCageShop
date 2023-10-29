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
        [BindProperty]
        public IFormFile ImageFile { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var imageFile = HttpContext.Request.Form.Files.FirstOrDefault();

            if (imageFile != null && imageFile.Length > 0)
            {
                _proRepo.Upload(Product.CageId, imageFile);
            }

            // Add product
            _proRepo.Add(Product);

            return RedirectToPage("/Admin/MProduct/Index");
        }

    }
}
