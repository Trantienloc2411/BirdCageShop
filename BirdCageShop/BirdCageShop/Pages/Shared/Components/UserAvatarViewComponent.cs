using Microsoft.AspNetCore.Mvc;
using Repository;

namespace BirdCageShop.Pages.Shared.Components
{
    public class UserAvatarViewComponent : ViewComponent
    {
        private readonly IUserRepository _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserAvatarViewComponent(IUserRepository userService, IHttpContextAccessor HttpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = HttpContextAccessor;
        }

        // Create a model class
        public class UserAvatarModel
        {
            public string UserImagePath { get; set; }
        }

        public IViewComponentResult Invoke()
        {
            // Get the current username from HttpContext
            var currentUsername = _httpContextAccessor.HttpContext.User.Identity.Name;
            // Assuming you have a method to get the current user's image path
            var userImagePath = _userService.GetUserImage(int.Parse(currentUsername));

            return View("Default", userImagePath);
        }
    }
}
