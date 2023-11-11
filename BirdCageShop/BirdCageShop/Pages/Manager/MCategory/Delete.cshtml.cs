using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MCategory
{
    public class DeleteModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepo;

        public DeleteModel(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }

        [BindProperty]
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = _categoryRepo.GetCategoryById(id);

            if (Category == null)
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

            Category = _categoryRepo.GetCategoryById(id);

            if (Category != null)
            {
                _categoryRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
