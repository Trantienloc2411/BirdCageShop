using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis;
using Repository;

namespace BirdCageShop.Pages.Users
{

    public class ProductDetailModel : PageModel
    {
        private readonly IProductRepository _proRepo;
        public ProductDetailModel()
        {
            _proRepo = new ProductRepository();
        }
        public int productID { get; set; }
        public Product product { get; set; }
        public Tuple<int, int> getFeedbackStatic { get; set; }
        public IActionResult OnGet(int productId)
        {
            try
            {
                productID = productId;
                product = new Product();
                product = _proRepo.GetProductById(productId);
                getFeedbackStatic = _proRepo.getFeedback(productId);
                if (product == null)
                {
                    return RedirectToAction("../Error");

                }
                else
                {
                    return Page();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
