using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MAccessory
{
    public class DetailsModel : PageModel
    {
        private readonly IAccessoryRepository _accRepo;

        public DetailsModel(IAccessoryRepository accessoryRepository)
        {
            _accRepo = accessoryRepository;
        }

        public Accessory Accessory { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Accessory = _accRepo.GetAccessoryById(id);
            ViewData["CategoryId"] = new SelectList(_accRepo.GetCategories(), "CategoryId", "CategoryId");
            ViewData["DiscountId"] = new SelectList(_accRepo.GetDiscounts(), "DiscountId", "DiscountId");
            if (Accessory == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
