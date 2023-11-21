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
        public IList<Order> OrderPending { get; set; }
        public IList<Order> OrderCancelled { get; set; }
        public IList<Order> OrderDelivering { get; set; }
        public IList<Order> OrderDelivered { get; set; }

        public int totalPendingOrder { get; set; }
        public int totalCancelOrder { get; set; }
        public int totalDeliveringOrder { get; set; }
        public int totalDeliveredOrder { get; set; }

        public int pageNo { get; set; }
        public int pageSize { get; set; }

        public IActionResult OnGet(int p = 1, int s = 5)
        {
            Order = _orderRepo.GetAll().ToList();
            OrderPending = _orderRepo.GetAllPending().ToList();
            OrderCancelled = _orderRepo.GetAllCancel().ToList();
            OrderDelivering = _orderRepo.GetAllDelivering().ToList();
            OrderDelivered = _orderRepo.GetAllDelivered().ToList();

            OrderPending = _orderRepo.getOrderPendingPages(p, s);
            OrderCancelled = _orderRepo.getOrderCancelPages(p, s);
            OrderDelivering = _orderRepo.getOrderDeliveringPages(p, s);
            OrderDelivered = _orderRepo.getOrderDeliveredPages(p, s);

            pageSize = s;

            totalPendingOrder = _orderRepo.getTotalOrderPendingPages();
            totalCancelOrder = _orderRepo.getTotalOrderCancelPages();
            totalDeliveringOrder = _orderRepo.getTotalOrderDeliveringPages();
            totalDeliveredOrder = _orderRepo.getTotalOrderDeliveredPages();

            pageNo = p;

            return Page();
        }
    }
}
