using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MFeedback
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
            ViewData["OrderId"] = new SelectList(_fbRepo.GetOrders(), "OrderId", "OrderName");
            ViewData["UserId"] = new SelectList(_fbRepo.GetUsers(), "UserId", "UserName");

            if (Feedback == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
