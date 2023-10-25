using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin.MRevenue
{
    public class IndexModel : PageModel
    {
        private readonly RevenueRepository _revenueRepo;

        public IndexModel(RevenueRepository revenueRepository)
        {
            _revenueRepo = revenueRepository;
        }
        public decimal? TotalOrderPrice { get; set; }
        public void OnGet()
        {
            var allOrders = _revenueRepo.GetAll();

            TotalOrderPrice = allOrders.Sum(order => order.OrderPrice);
        }
    }
}
