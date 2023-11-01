using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MOrderDetail
{
    public class DeleteModel : PageModel
    {
        private readonly IOrderDetailRepository _orderDetailRepo;

        public DeleteModel(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepo = orderDetailRepository;
        }

        [BindProperty]
        public OrderDetail OrderDetail { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderDetail = _orderDetailRepo.GetOrderDetailById(id);

            if (OrderDetail == null)
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

            OrderDetail = _orderDetailRepo.GetOrderDetailById(id);

            if (OrderDetail != null)
            {
                _orderDetailRepo.Delete(id);
            }

            return RedirectToPage("./Index");
        }
    }
}
