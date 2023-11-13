using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MCategory
{
    public class CreateModel : PageModel
    {
        private readonly ICategoryRepository _context;

        public CreateModel(ICategoryRepository categoryRepository)
        {
            _context = categoryRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Add(Category);
            return RedirectToPage("./Index");
        }
    }
}
