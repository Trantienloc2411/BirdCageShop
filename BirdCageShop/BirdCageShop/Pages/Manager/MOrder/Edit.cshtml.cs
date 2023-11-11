using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MOrder
{
    public class EditModel : PageModel
    {
        private readonly IOrderRepository _orderRepo;

        public EditModel(IOrderRepository orderRepository)
        {
            _orderRepo = orderRepository;
        }

        [BindProperty]
        public Order Order { get; set; }

        public IActionResult OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = _orderRepo.GetOrderById(id);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _orderRepo.ManagerUpdate(Order);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return RedirectToPage("./Index");
        }
    }
}
