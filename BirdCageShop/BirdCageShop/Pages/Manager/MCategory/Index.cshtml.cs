using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MCategory
{
    public class IndexModel : PageModel
    {
        private readonly CategoryRepository _categoryRepo;

        public IndexModel()
        {
            _categoryRepo = new CategoryRepository();
        }

        public IList<Category> Category { get; set; }

        public IActionResult OnGet()
        {
            Category = _categoryRepo.GetAll().ToList();
            return Page();
        }
    }
}
