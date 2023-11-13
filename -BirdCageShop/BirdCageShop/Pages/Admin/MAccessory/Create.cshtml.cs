using BirdCageShop.wwwroot.UploadService;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MAccessory
{
    public class CreateModel : PageModel
    {
        private readonly IAccessoryRepository _accRepo;
        private readonly IUploadService _uploadService;
        public string filePath;

        public CreateModel(IAccessoryRepository accessoryRepository, IUploadService uploadService)
        {
            _accRepo = accessoryRepository;
            this._uploadService = uploadService;
        }

        public IActionResult OnGet()
        {
            // Ensure Product is instantiated
            Accessory = new Accessory();

            var listCategories = _accRepo.GetCategories();
            var listDiscounts = _accRepo.GetDiscounts();
            ViewData["CategoryId"] = new SelectList(listCategories, "CategoryId", "CategoryName");
            ViewData["DiscountId"] = new SelectList(listDiscounts, "DiscountId", "DiscountName");
            return Page();
        }

        [BindProperty]
        public Accessory Accessory { get; set; }
        [BindProperty]
        public String AccessoryImg { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(IFormFile AccessoryImg)
        {
            if (AccessoryImg != null)
            {
                Accessory.AccessoryImg = await _uploadService.UploadFileAsync(AccessoryImg);
            }
            // Add product
            _accRepo.Add(Accessory);

            return RedirectToPage("/Admin/MProduct/Index");
        }

    }

}
