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
        public string CageImg { get; set; }

        public IActionResult OnGet()
        {
            // Ensure Product is instantiated
            Product = new BusinessObjects.Models.Product();

            var listCategories = _proRepo.GetCategories();
            var listDiscounts = _proRepo.GetDiscounts();
            ViewData["CategoryId"] = new SelectList(listCategories, "CategoryId", "CategoryName");
            ViewData["DiscountId"] = new SelectList(listDiscounts, "DiscountId", "DiscountName");
            return Page();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile CageImg)
        {
            if (CageImg != null)
            {
                Product.CageImg = await _uploadService.UploadFileAsync(CageImg);
            }

            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            //var imageFile = HttpContext.Request.Form.Files.FirstOrDefault();

            //if (imageFile != null && imageFile.Length > 0)
            //{
            //    _proRepo.Upload(Product.CageId, imageFile);
            //}

            // Add product
            _proRepo.Add(Product);

            return RedirectToPage("/Admin/MProduct/Index");
        }

    }
}
