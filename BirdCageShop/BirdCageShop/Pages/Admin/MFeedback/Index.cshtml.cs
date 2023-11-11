using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MFeedback
{
    public class IndexModel : PageModel
    {
        private readonly FeedbackRepository _fbRepo;

        public IndexModel()
        {
            _fbRepo = new FeedbackRepository();
        }

        public IList<Feedback> Feedback { get; set; }

        public IActionResult OnGet()
        {
            Feedback = _fbRepo.GetAll().ToList();
            ViewData["OrderId"] = new SelectList(_fbRepo.GetOrders(), "OrderId", "OrderName");
            ViewData["UserId"] = new SelectList(_fbRepo.GetUsers(), "UserId", "OrderId");
            return Page();
        }
    }
}
