using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MProduct
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _proRepo;

        public DeleteModel(IProductRepository productRepository)
        {
            _proRepo = productRepository;
        }

        [BindProperty]
        public BusinessObjects.Models.Product Product { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
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
            return Page();
        }

        public IActionResult OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = _proRepo.GetProductById(id);

            if (Product != null)
            {
                _proRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
