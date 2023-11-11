using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MCategory
{
    public class DetailsModel : PageModel
    {
        private readonly ICategoryRepository _categoryRepo;

        public DetailsModel(ICategoryRepository categoryRepository)
        {
            _categoryRepo = categoryRepository;
        }

        public Category Category { get; set; }

        public IActionResult OnGet(int id)
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
    }
}
