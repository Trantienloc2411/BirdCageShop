using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MDiscount
{
    public class DetailsModel : PageModel
    {
        private readonly IDiscountRepository _discountRepo;

        public DetailsModel(IDiscountRepository discountRepository)
        {
            _discountRepo = discountRepository;
        }

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
    }
}
