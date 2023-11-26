using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repository;

namespace BirdCageShop.Pages.Manager.MUser
{
    public class IndexModel : PageModel
    {
        private readonly UserRepository _userRepo;

        public IndexModel()
        {
            _userRepo = new UserRepository();
        }

        public IList<User> User { get; set; }
        public int totalUser { get; set; }

        public int pageNo { get; set; }
        public int pageSize { get; set; }

        public IActionResult OnGet(int p = 1, int s = 5)
        {
            User = _userRepo.GetAllUser().ToList();
            User = _userRepo.getUserPages(p, s);
            ViewData["RoleName"] = new SelectList(_userRepo.GetUserRole(), "RoleId", "RoleName");

            pageSize = s;

            totalUser = _userRepo.getTotalUserPages();

            pageNo = p;
            ViewData["RoleName"] = new SelectList(_userRepo.GetUserRole().Where(u => u.RoleId != 4 && u.RoleId != 2), "RoleName", "RoleName");
            return Page();
        }

        public IActionResult OnPostSearch()
        {
            string search = Request.Form["SearchString"];
            if (search != null)
            {
                User = _userRepo.GetListUserByName(search);
                return Page();
            }
            return Page();
        }
    }
}
