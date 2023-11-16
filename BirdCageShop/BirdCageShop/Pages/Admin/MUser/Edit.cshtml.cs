using BirdCageShop.wwwroot.UploadService;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace BirdCageShop.Pages.Admin.MUser
{
    public class EditModel : PageModel
    {
        private readonly IUserRepository _userRepo;
        private readonly IUploadService uploadService;
        private readonly ILogger<EditModel> _logger;

        public EditModel(IUserRepository userRepository, IUploadService uploadService, ILogger<EditModel> logger)
        {
            _userRepo = userRepository;
            this.uploadService = uploadService ?? throw new ArgumentNullException(nameof(uploadService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [BindProperty]
        public User User { get; set; }
        [BindProperty]
        public string? UserImg { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User = _userRepo.GetUserById(id);

            if (User == null)
            {
                return NotFound();
            }
            // Ensure CageImg is not null to avoid issues in OnPostAsync
            if (User.UserImg == null)
            {
                User.UserImg = ""; // or set it to a default value if necessary
            }
            var listRoles = _userRepo.GetUserRole().Where(u => u.RoleId != 4);
            ViewData["RoleId"] = new SelectList(listRoles, "RoleId", "RoleName");
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
            string oldUserImgPath = _userRepo.GetUserById(User.UserId).UserImg;

            // Check if files are uploaded
            if (HttpContext.Request.Form.Files.Any())
            {
                var UserImg = HttpContext.Request.Form.Files[0];

                // If there was an old image, delete it
                if (!string.IsNullOrEmpty(oldUserImgPath) && System.IO.File.Exists(oldUserImgPath))
                {
                    // You may want to add error handling here in case the delete fails
                    System.IO.File.Delete(oldUserImgPath);
                }
                // Call the file upload service to save the new file
                User.UserImg = await uploadService.UploadFileAsync(UserImg);
            }
            // No new file uploaded, keep the existing UserImg value
            else
            {
                User.UserImg = oldUserImgPath;
            }

            try
            {
                _userRepo.Update(User);
                // Add a log statement to indicate a successful update
                _logger.LogInformation("User updated successfully.");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Log the exception details
                _logger.LogError(ex, "Concurrency exception during User update.");
                // Handle concurrency exception as needed
                ModelState.AddModelError("", "Concurrency error. The record you attempted to edit was modified by another user after you got the original value.");
                return Page();
            }
            catch (Exception ex)
            {
                // Log the general exception details
                _logger.LogError(ex, "An error occurred during User update.");
                // Handle other exceptions as needed
                ModelState.AddModelError("", "An error occurred during the update process.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
