using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users.UOrder
{
	public class CheckoutModel : PageModel
    {
        private IOrderRepository _ordRepo;
        public CheckoutModel()
        {
            _ordRepo = new OrderRepository();
        }
        public void OnGet(int orderID)
        {

        }
    }
}
