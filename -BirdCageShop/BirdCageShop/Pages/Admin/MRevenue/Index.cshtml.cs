using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MRevenue
{
    public class IndexModel : PageModel
    {
        private readonly IRevenueRepository _revenueRepo;
        private readonly IOrderRepository _orderRepo;


        public IndexModel(IRevenueRepository revenueRepository, IOrderRepository orderRepository)
        {
            _revenueRepo = revenueRepository;
            _orderRepo = orderRepository;
        }
        public decimal? TotalOrderPrice { get; set; }
        public IList<Order> Order { get; set; }
        public IList<User> User { get; set; }

        public void OnGet()
        {
            Order = _orderRepo.GetAll().ToList();
            var allOrders = _revenueRepo.GetAll();

            TotalOrderPrice = allOrders.Sum(order => order.OrderPrice);
        }
    }
}
