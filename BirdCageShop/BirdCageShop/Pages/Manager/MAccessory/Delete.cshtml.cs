using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MAccessory
{
    public class DeleteModel : PageModel
    {
        private readonly IAccessoryRepository _accRepo;

        public DeleteModel(IAccessoryRepository accessoryRepository)
        {
            _accRepo = accessoryRepository;
        }

        [BindProperty]
        public Accessory Accessory { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accessory = _accRepo.GetAccessoryById(id);

            if (Accessory != null)
            {
                _accRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
