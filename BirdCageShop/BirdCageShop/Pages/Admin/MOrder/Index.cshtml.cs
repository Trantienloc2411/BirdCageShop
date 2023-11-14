using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MOrder
{
    public class IndexModel : PageModel
    {
        private readonly OrderRepository _orderRepo;

        public IndexModel()
        {
            _orderRepo = new OrderRepository();
        }

        public IList<Order> Order { get; set; }

        public IActionResult OnGet()
        {
            Order = _orderRepo.GetAll().ToList();
            return Page();
        }
    }
}
