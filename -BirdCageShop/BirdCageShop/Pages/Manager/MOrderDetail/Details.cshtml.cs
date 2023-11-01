using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MOrderDetail
{
    public class DetailsModel : PageModel
    {
        private readonly IOrderDetailRepository _oerderDetailRepo;

        public DetailsModel(IOrderDetailRepository orderDetailRepository)
        {
            _oerderDetailRepo = orderDetailRepository;
        }

        public OrderDetail OrderDetail { get; set; }

        public IActionResult OnGet(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = _oerderDetailRepo.GetOrderDetailById(id);

            if (OrderDetail == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
