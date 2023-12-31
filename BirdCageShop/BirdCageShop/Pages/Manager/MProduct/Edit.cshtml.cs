﻿using BirdCageShop.wwwroot.UploadService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BirdCageShop.Pages.Manager.MProduct
{
    public class EditModel : PageModel
    {
        private readonly IProductRepository _proRepo;
        private readonly IUploadService uploadService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IProductRepository productRepository, IUploadService uploadService, ILogger<EditModel> logger)
        {
            _proRepo = productRepository;
            this.uploadService = uploadService ?? throw new ArgumentNullException(nameof(uploadService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BindProperty]
        public BusinessObjects.Models.Product Product { get; set; }
        [BindProperty]
        public string? CageImg { get; set; }

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

            // Ensure CageImg is not null to avoid issues in OnPostAsync
            if (Product.CageImg == null)
            {
                Product.CageImg = ""; // or set it to a default value if necessary
            }

            var listCategories = _proRepo.GetCategories();
            var listDiscounts = _proRepo.GetDiscounts();
            ViewData["CategoryId"] = new SelectList(listCategories, "CategoryId", "CategoryName");
            ViewData["DiscountId"] = new SelectList(listDiscounts, "DiscountId", "DiscountName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Save the path of the old image
            string oldCageImgPath = _proRepo.GetProductById(Product.CageId).CageImg;

            // Check if files are uploaded
            if (HttpContext.Request.Form.Files.Any())
            {
                var CageImg = HttpContext.Request.Form.Files[0];

                // If there was an old image, delete it
                if (!string.IsNullOrEmpty(oldCageImgPath) && System.IO.File.Exists(oldCageImgPath))
                {
                    // You may want to add error handling here in case the delete fails
                    System.IO.File.Delete(oldCageImgPath);
                }
                // Call the file upload service to save the new file
                Product.CageImg = await uploadService.UploadFileAsync(CageImg);
            }
            // No new file uploaded, keep the existing CageImg value
            else
            {
                Product.CageImg = oldCageImgPath;
            }

            try
            {
                _proRepo.Update(Product);
                // Add a log statement to indicate a successful update
                _logger.LogInformation("Product updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the exception details
                _logger.LogError(ex, "Concurrency exception during product update.");
                // Handle concurrency exception as needed
                ModelState.AddModelError("", "Concurrency error. The record you attempted to edit was modified by another user after you got the original value.");
                return Page();
            }
            catch (Exception ex)
            {
                // Log the general exception details
                _logger.LogError(ex, "An error occurred during product update.");
                // Handle other exceptions as needed
                ModelState.AddModelError("", "An error occurred during the update process.");
                return Page();
            }

            return RedirectToPage("./Index");
        }

    }
}
