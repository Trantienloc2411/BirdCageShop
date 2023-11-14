using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MDiscount
{
    public class IndexModel : PageModel
    {
        private readonly DiscountRepository _DiscountRepo;

        public IndexModel()
        {
            _DiscountRepo = new DiscountRepository();
        }

        public IList<Discount> Discount { get; set; }

        public IActionResult OnGet()
        {
            Discount = _DiscountRepo.GetAll().ToList();
            return Page();
        }
    }
}
