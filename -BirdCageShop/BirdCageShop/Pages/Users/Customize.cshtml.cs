using BirdCageShop.wwwroot.UploadService;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class CustomizeModel : PageModel
    {
        public BusinessObjects.Models.Product Product { get; set; }
        private readonly IUploadService _uploadService;
        private readonly IProductRepository _proRepos;
        [BindProperty]
        public string? CageIMG { get; set; }
        public CustomizeModel(IUploadService uploadService)
        {
            _uploadService = uploadService;
            _proRepos = new ProductRepository();
        }

        public async Task<IActionResult> OnPostAsync(IFormFile CageIMG)
            
        {
            Product = new BusinessObjects.Models.Product();
            if(CageIMG != null)
            {
                 Product.CageImg = await _uploadService.UploadFileAsync(CageIMG);
            }
            string sizeValue = Request.Form["sizeValue"];
            string quantityValue = Request.Form["quantityValue"];
            string nanValue = Request.Form["nanValue"];
            string materialValue = Request.Form["materialValue"];
            string cageNoteValue = Request.Form["cageNote"];
            if (int.TryParse(quantityValue, out int quantity) && int.TryParse(nanValue, out int nan))
            {
                //Tạo lồng
                Product.CageName = "Lồng tự tạo của " + HttpContext.Session.GetString("userName");
                Product.Quantity = quantity;
                Product.Material = materialValue;
                Product.Bar = nan;
                Product.Description = cageNoteValue;
                Product.CageStatus = 2;
                
                return Page();

                

            }
            else
            {
                TempData["errorMessage"] = "Lỗi! Giá trị bạn nhập không hợp lệ (Số nan / Số lượng là số nguyên và lớn hơn 0)";
                return Page();
            }


        }

    }
}
