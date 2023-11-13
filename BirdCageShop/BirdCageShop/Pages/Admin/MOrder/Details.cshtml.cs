using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MOrder
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderRepository _oerderRepo;

        public DetailsModel(IOrderRepository orderRepository)
        {
            _oerderRepo = orderRepository;
        }

        public Order Order { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = _oerderRepo.GetOrderById(id);

            if (Order == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
