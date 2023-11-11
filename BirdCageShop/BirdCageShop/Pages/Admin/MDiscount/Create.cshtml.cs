using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MDiscount
{
    public class CreateModel : PageModel
    {
        private readonly IDiscountRepository _discountRepo;

        public CreateModel(IDiscountRepository discountRepository)
        {
            _discountRepo = discountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Discount Discount { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _discountRepo.Add(Discount);

            return RedirectToPage("./Index");
        }
    }
}
