using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MFeedback
{
    public class DetailsModel : PageModel
    {
        private readonly IFeedbackRepository _fbRepo;

        public DetailsModel(IFeedbackRepository feedbackRepository)
        {
            _fbRepo = feedbackRepository;
        }

        public Feedback Feedback { get; set; }

        public IActionResult OnGetAsync(int id)
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
    }
}
