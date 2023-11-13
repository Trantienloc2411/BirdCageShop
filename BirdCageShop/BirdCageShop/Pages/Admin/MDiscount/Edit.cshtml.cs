using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MDiscount
{
    public class EditModel : PageModel
    {
        private readonly IDiscountRepository _discountRepo;

        public EditModel(IDiscountRepository discountRepository)
        {
            _discountRepo = discountRepository;
        }

        [BindProperty]
        public Discount Discount { get; set; }

        public IActionResult OnGet(int id)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _discountRepo.Update(Discount);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
