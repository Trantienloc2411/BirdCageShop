using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Admin
{
    public class LogoutModel : PageModel
    {
        private ICartRepository _cart;
        public LogoutModel() 
        {
            _cart = new CartRepository();
        }

        public IActionResult OnPost()
        {
            // Perform logout actions (e.g., sign out the user)
            
            // Example: HttpContext.SignOutAsync();
            
            HttpContext.Session.Clear();
            var cartList = _cart.showCart();
            if(cartList != null)
            {
                _cart.clearCart();
            }

            return RedirectToPage("../Index"); // Redirect to the home page after logout
        }
    }
}
