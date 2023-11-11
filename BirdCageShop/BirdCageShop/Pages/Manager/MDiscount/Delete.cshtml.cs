using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MDiscount
{
    public class DeleteModel : PageModel
    {
        private readonly IDiscountRepository _discountRepo;

        public DeleteModel(IDiscountRepository discountRepository)
        {
            _discountRepo = discountRepository;
        }

        [BindProperty]
        public Discount Discount { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discount = _discountRepo.GetDiscountById(id);

            if (Discount == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Discount = _discountRepo.GetDiscountById(id);

            if (Discount != null)
            {
                _discountRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
