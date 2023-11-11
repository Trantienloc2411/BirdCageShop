using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MFeedback
{
    public class CreateModel : PageModel
    {
        private readonly IFeedbackRepository _fbRepo;

        public CreateModel(IFeedbackRepository feedbackRepository)
        {
            _fbRepo = feedbackRepository;
        }

        public IActionResult OnGet()
        {
            Feedback = new Feedback();
            var listOrders = _fbRepo.GetOrders();
            var listUsers = _fbRepo.GetUsers();
            TempData["OrderId"] = new SelectList(listOrders, "OrderId", "OrderName", Feedback.OrderId);
            TempData["UserId"] = new SelectList(listUsers, "UserId", "UserName", Feedback.UserId);
            return Page();
        }

        [BindProperty]
        public Feedback Feedback { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _fbRepo.Add(Feedback);

            return RedirectToPage("./Index");
        }
    }
}
