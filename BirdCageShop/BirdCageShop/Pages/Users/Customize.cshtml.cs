using BirdCageShop.wwwroot.UploadService;
using MessagePack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class CustomizeModel : PageModel
    {
        [BindProperty]
        public BusinessObjects.Models.Product Product { get; set; }
        private readonly IUploadService _uploadService;
        private readonly IProductRepository _proRepos;
        private readonly ICartRepository _cartRepo;
        [BindProperty]
        public IFormFile CageImg { get; set; }
        public CustomizeModel(IUploadService uploadService)
        {
            _uploadService = uploadService;
            _proRepos = new ProductRepository();
            _cartRepo = new CartRepository();
        }


        public async Task<IActionResult> OnPostAsync(IFormFile CageImg)
        {
            if (HttpContext.Session.GetInt32("userID") == null)
            {
                TempData["errorMessage"] = "Hãy đăng nhập trước khi tạo mới lồng của bạn nhé. Mình chuyển đến trang đăng nhập giúp bạn rồi nè";
                return RedirectToPage("/Login/Index");
            }
            TempData["errorMessage"] = "";
            Product = new BusinessObjects.Models.Product();
            if (CageImg != null)
            {
                Product.CageImg = await _uploadService.UploadFileAsync(CageImg);
            }
            string sizeValue = Request.Form["sizeValue"];
            string quantityValue = Request.Form["quantityValue"];
            if(quantityValue.Length == 0)
            {
                quantityValue = "1";    
            }
            string nanValue = Request.Form["nanValue"];
            string materialValue = Request.Form["materialValue"];
            string cageNoteValue = Request.Form["cageNote"];
            string productEst = Request.Form["totalEstimatedPrice"];
            if (int.TryParse(quantityValue, out int quantity) && int.TryParse(nanValue, out int nan) && decimal.TryParse(productEst,out decimal price))
            {
                //Tạo lồng
                string name = "Lồng tự tạo của " + HttpContext.Session.GetInt32("userID");
                Product.CageName = name;
                Product.Quantity = quantity;
                Product.Material = materialValue;
                Product.Size = sizeValue;
                Product.Bar = nan;
                Product.Description = cageNoteValue;
                Product.CageStatus = 2;
                Product.Price = price;
                int prodID = _proRepos.AddCustomizeCage(Product);
                if (prodID != 0)
                {
                    int addToCart = _cartRepo.addProductToCart(prodID, (int)Product.Quantity, 0);
                    if (addToCart != 0)
                    {
                        TempData["successMessage"] = "Lồng tự tạo của bạn đã nằm trong giỏ hàng!";
                        return RedirectToPage("./UCart/Index");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Thêm vào giỏ hàng thất bại!";
                    }

                }
                else
                {
                    TempData["errorMessage"] = "Tạo lồng thất bại!";
                }
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
