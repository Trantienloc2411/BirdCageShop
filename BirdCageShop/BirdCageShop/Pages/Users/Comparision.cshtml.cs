using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class ComparisionModel : PageModel
    {
        private IProductRepository _proRepo;
        private ICartRepository _cartRepo;
        public List<Product> comparePro;
        public ComparisionModel()
        {
            _cartRepo = new CartRepository();
            _proRepo = new ProductRepository();
            comparePro = new List<Product>();
        }
        public void OnGet()
        {
            int prod1 = HttpContext.Session.GetInt32("pID1") ?? 0;
            int prod2 = HttpContext.Session.GetInt32("pID2") ?? 0;
            if(prod1 != 0 && prod2 != 0)
            {
                comparePro = _proRepo.comparisionProduct(prod1,prod2);
            }
            else
            {
                comparePro = new List<Product>(); 
            }
        }
        public void OnPost(int pID)
        {
            int prod1 = HttpContext.Session.GetInt32("pID1") ?? 0;
            int prod2 = HttpContext.Session.GetInt32("pID2") ?? 0;
            if (pID == prod1) HttpContext.Session.SetInt32("pID1", 0);
            else if (pID == prod2) HttpContext.Session.SetInt32("pID2", 0);
            OnGet();
            Page();
        }

    }
}
