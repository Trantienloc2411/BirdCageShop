using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MAccessory
{
    public class IndexModel : PageModel
    {
        private readonly AccessoryRepository _accRepo;

        public IndexModel()
        {
            _accRepo = new AccessoryRepository();
        }

        public IList<Accessory> Accessory { get; set; }

        public int totalAccessory { get; set; }

        public int pageNo { get; set; }

        public int pageSize { get; set; }

        public IActionResult OnGet(int p = 1, int s = 5)
        {
            Accessory = _accRepo.GetAll().ToList();
            Accessory = _accRepo.getAccessoryPages(p, s);
            pageSize = s;
            totalAccessory = _accRepo.getTotalAccessoryPages();
            pageNo = p;
            ViewData["CategoryId"] = new SelectList(_accRepo.GetCategories(), "CategoryId", "CategoryId");
            ViewData["DiscountId"] = new SelectList(_accRepo.GetDiscounts(), "DiscountId", "DiscountId");
            return Page();
        }


        public IActionResult OnPostSearch()
        {
            string search = Request.Form["SearchString"];
            if (search != null)
            {
                Accessory = _accRepo.GetAccessoryByName(search);
                return Page();
            }
            return Page();
        }
    }
}
