using BirdCageShop.wwwroot.UploadService;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MProduct
{
    public class CreateModel : PageModel
    {
        private readonly IProductRepository _proRepo;
        private readonly IUploadService _uploadService;
        public string filePath;

        public CreateModel(IProductRepository productRepository, IUploadService uploadService)
        {
            _proRepo = productRepository;
            this._uploadService = uploadService;

        }


        [BindProperty]
        public BusinessObjects.Models.Product Product { get; set; }
        [BindProperty]
        public String CageImg { get; set; }

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

        public async Task<IActionResult> OnPostAsync(IFormFile CageImg)
        {
            if (CageImg != null)
            {
                Product.CageImg = await _uploadService.UploadFileAsync(CageImg);
            }
            

            _proRepo.Add(Product);

            return RedirectToPage("/Admin/MProduct/Index");
        }

    }
}
