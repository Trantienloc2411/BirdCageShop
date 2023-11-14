using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Manager.MRevenue
{
    public class IndexModel : PageModel
    {
        private readonly IRevenueRepository _revenueRepo;
        private readonly IOrderRepository _orderRepo;
        private readonly IUserRepository _userRepo;

        public IndexModel(IRevenueRepository revenueRepository, IOrderRepository orderRepository, IUserRepository userRepository)
        {
            _revenueRepo = revenueRepository;
            _orderRepo = orderRepository;
            _userRepo = userRepository;
        }
        public decimal? TotalOrderPrice { get; set; }
        public IList<Order> Order { get; set; }
        public List<User> UserName { get; set; }

        public void OnGet()
        {
            Order = _orderRepo.GetAll().ToList();
            var allOrders = _revenueRepo.GetAll();

            TotalOrderPrice = allOrders.Sum(order => order.OrderPrice);
        }
    }
}
