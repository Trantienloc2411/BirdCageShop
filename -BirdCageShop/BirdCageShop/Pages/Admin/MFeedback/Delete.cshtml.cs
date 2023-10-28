using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MFeedback
{
    public class DeleteModel : PageModel
    {
        private readonly IFeedbackRepository _fbRepo;

        public DeleteModel(IFeedbackRepository feedbackRepository)
        {
            _fbRepo = feedbackRepository;
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feedback = _fbRepo.GetFeedbackrById(id);

            if (Feedback == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Feedback = _fbRepo.GetFeedbackrById(id);

            if (Feedback != null)
            {
                _fbRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
