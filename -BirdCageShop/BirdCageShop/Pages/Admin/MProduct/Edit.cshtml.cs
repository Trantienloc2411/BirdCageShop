using BirdCageShop.wwwroot.UploadService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MProduct
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _proRepo;
        private readonly IUploadService _uploadService;

        public EditModel(IProductRepository productRepository, IUploadService uploadService)
        {
            _proRepo = productRepository;
            _uploadService = uploadService;
        }

        [BindProperty]
        public BusinessObjects.Models.Product Product { get; set; }
        [BindProperty]
        public String CageImg { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _proRepo.GetProductById(id);

            if (Product == null)
            {
                return NotFound();
            }
            var listCategories = _proRepo.GetCategories();
            var listDiscounts = _proRepo.GetDiscounts();
            TempData["CategoryId"] = new SelectList(listCategories, "CategoryId", "CategoryName", Product.CategoryId);
            TempData["DiscountId"] = new SelectList(listDiscounts, "DiscountId", "DiscountName", Product.DiscountId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile CageImg)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                if (CageImg != null)
                {
                    Product.CageImg = await _uploadService.UploadFileAsync(CageImg);
                }
                _proRepo.Update(Product);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
