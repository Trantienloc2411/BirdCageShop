using BirdCageShop.wwwroot.UploadService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BirdCageShop.Pages.Manager.MAccessory
{
    public class EditModel : PageModel
    {
        private readonly IAccessoryRepository _accRepo;
        private readonly IUploadService uploadService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IAccessoryRepository accessoryRepository, IUploadService uploadService, ILogger<EditModel> logger)
        {
            _accRepo = accessoryRepository;
            this.uploadService = uploadService ?? throw new ArgumentNullException(nameof(uploadService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BindProperty]
        public BusinessObjects.Models.Accessory Accessory { get; set; }
        [BindProperty]
        public string? AccessoryImg { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accessory = _accRepo.GetAccessoryById(id);

            if (Accessory == null)
            {
                return NotFound();
            }
            var listCategories = _accRepo.GetCategories();
            var listDiscounts = _accRepo.GetDiscounts();
            TempData["CategoryId"] = new SelectList(listCategories, "CategoryId", "CategoryName", Accessory.CategoryId);
            TempData["DiscountId"] = new SelectList(listDiscounts, "DiscountId", "DiscountName", Accessory.DiscountId);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(IFormFile AccessoryImg)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the path of the old image
            string oldCageImgPath = Accessory.AccessoryImg;

            // Check if a file is uploaded
            if (AccessoryImg != null && AccessoryImg.Length > 0)
            {
                // If there was an old image, delete it
                if (!string.IsNullOrEmpty(oldCageImgPath))
                {
                    // You may want to add error handling here in case the delete fails
                    System.IO.File.Delete(oldCageImgPath);
                }
                // Call the file upload service to save the new file
                Accessory.AccessoryImg = await uploadService.UploadFileAsync(AccessoryImg);
            }

            try
            {
                _accRepo.Update(Accessory);
                // Add a log statement to indicate a successful update
                _logger.LogInformation("Accessory updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the exception details
                _logger.LogError(ex, "Concurrency exception during Accessory update.");
                // Handle concurrency exception as needed
                ModelState.AddModelError("", "Concurrency error. The record you attempted to edit was modified by another user after you got the original value.");
                return Page();
            }
            catch (Exception ex)
            {
                // Log the general exception details
                _logger.LogError(ex, "An error occurred during Accessory update.");
                // Handle other exceptions as needed
                ModelState.AddModelError("", "An error occurred during the update process.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
