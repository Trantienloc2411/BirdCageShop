using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MOrderDetail
{
    public class IndexModel : PageModel
    {
        private readonly OrderDetailRepository _orderDetailRepo;

        public IndexModel()
        {
            _orderDetailRepo = new OrderDetailRepository();
        }

        public IList<OrderDetail> OrderDetail { get; set; }

        public IActionResult OnGet()
        {
            OrderDetail = _orderDetailRepo.GetAll().ToList();
            ViewData["OrderId"] = new SelectList(_orderDetailRepo.GetOrders(), "OrderId", "OrderId");
            ViewData["AccessoryId"] = new SelectList(_orderDetailRepo.GetAccessories(), "AccessoryId", "AccessoryId");
            ViewData["CageId"] = new SelectList(_orderDetailRepo.GetProducts(), "CageId", "CageId");
            return Page();
        }
    }
}
