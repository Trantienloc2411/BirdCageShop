using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Admin.MProduct
{
    public class IndexModel : PageModel
    {
        private readonly ProductRepository _proRepo;

        public IndexModel()
        {
            _proRepo = new ProductRepository();
        }

        public IList<BusinessObjects.Models.Product> Product { get; set; }
        public int totalProduct { get; set; }

        public int pageNo { get; set; }

        public int pageSize { get; set; }

        public IActionResult OnGet(int p = 1, int s = 5)
        {
            Product = _proRepo.GetAll().ToList();
            Product = _proRepo.getProductPages(p, s);
            pageSize = s;
            totalProduct = _proRepo.getTotalProductPages();
            pageNo = p;
            ViewData["CategoryId"] = new SelectList(_proRepo.GetCategories(), "CategoryId", "CategoryId");
            ViewData["DiscountId"] = new SelectList(_proRepo.GetDiscounts(), "DiscountId", "DiscountId");
            return Page();
        }


        public IActionResult OnPostSearch()
        {
            string search = Request.Form["SearchString"];
            if (search != null)
            {
                Product = _proRepo.GetListProductByName(search);
                return Page();
            }
            return Page();
        }
    }
}

