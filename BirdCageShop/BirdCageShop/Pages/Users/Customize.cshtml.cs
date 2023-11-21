using BirdCageShop.wwwroot.UploadService;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class CustomizeModel : PageModel
    {
        private readonly IUploadService _uploadService;
        private readonly IProductRepository _proRepos;
        private readonly ICartRepository _cartRepo;

        [BindProperty]
        public string cageType { get; set; }
        [BindProperty]
        public string lidCage {  get; set; }
        [BindProperty]
        public string barCageType { get; set; }
        [BindProperty]
        public int barCageCount { get; set; } = 50;
        [BindProperty]
        public int barCount { get; set; }

        [BindProperty]
        public string doorCageType { get; set; }
        [BindProperty]
        public string doorCageSize { get; set; }
        [BindProperty]
        public string baseCage { get;set ; }
        [BindProperty]
        public string orderPrice { get; set; }
        
        
        public IFormFile CageImg { get; set; }
        public CustomizeModel(IUploadService uploadService)
        {
            _uploadService = uploadService;
            _proRepos = new ProductRepository();
            _cartRepo = new CartRepository();
        }

        public void OnPost()
        {
            doorCageType = Request.Form["doorCage"];
            string? orderEst = Request.Form["OrderEst"];
            string? OrderPrice = Request.Form["OrderPrice"];
            
            Page();
        }



    }
}
