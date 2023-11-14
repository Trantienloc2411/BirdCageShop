using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MRevenue
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
        public string UserName { get; set; }

        public void OnGet(int? UserId)
        {
            Order = _orderRepo.GetAll().ToList();
            ViewData["UserName"] = new SelectList(_revenueRepo.GetUsers(), "UserName", "UserName");
            var allOrders = _revenueRepo.GetAll();
            TotalOrderPrice = allOrders.Sum(order => order.OrderPrice);
        }
    }
}
