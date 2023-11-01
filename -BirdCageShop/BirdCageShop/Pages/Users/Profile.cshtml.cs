﻿using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class ProfileModel : PageModel
    {
        private IUserRepository userRepository;
        
        public User user { get; set; }
        [BindProperty]
        public string UserEmail { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string UserName {  get; set; }
        [BindProperty]
        public string PasswordRepeat { get; set; }
        [BindProperty]
        public string Address { get; set; }
        [BindProperty]
        public DateTime dob { get; set; }
        [BindProperty]
        public string Phone { get; set; }

        public string ErrorMessage { get; set; }
        public ProfileModel()
        {
            userRepository = new UserRepository();
        }
        public IActionResult OnGet()
        {
            try
            {
                
                
                if(HttpContext.Session.Id == null)
                {
                    TempData["errorMessage"] = "Hãy xác thực để xem thông tin của mình nhé";
                    RedirectToPage("../Login/Index");
                }

                var _user = userRepository.GetUserById((int)HttpContext.Session.GetInt32("userID"));
                if (_user != null)
                {
                    user = _user;

                    UserEmail = user.Email;
                    Password = user.UserPassword;
                    UserName = user.UserName;
                    PasswordRepeat = user.UserPassword;
                    Address = user.Address;
                    dob = (DateTime)user.DoB;
                    Phone = user.Phone;
                    return Page();
                }
                return Page();
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Error: " + ex.Message;
                return Page();
            }

        }

        public IActionResult OnPost()
        {
            try
            {
                
                string currentEmail = HttpContext.Session.GetString("userEmail");
                bool isEmailExisted = userRepository.IsEmailExistedExceptEmailCurrent(UserEmail, currentEmail);
                if (isEmailExisted)
                {
                    TempData["errorMessage"] = "Email này đã tồn tại! Sử dụng email khác";
                    return Page();
                }
                else if (Password.Length < 6 || Password == null)
                {
                    TempData["errorMessage"] = "Mật khẩu yếu! Mật khẩu cần ít nhất 7 kí tự";
                    return Page();
                }
                else if (Password != PasswordRepeat || PasswordRepeat == null)
                {
                    TempData["errorMessage"] = "Mật khẩu và mật khẩu lặp lại không khớp! Thử lại";
                    return Page();
                }
                else
                {
                    user = new User();
                    user.UserId = (int)HttpContext.Session.GetInt32("userID");
                    user.UserName = UserName;
                    user.Email = UserEmail;
                    user.Phone = Phone;
                    user.Address = Address;
                    user.DoB = dob;
                    user.UserPassword = Password;
                    int success = userRepository.UpdateUserProfile(user);
                    if(success != 0)
                    {
                        TempData["successMessage"] = "Thông tin được cập nhật thành công! Hãy tải lại trang để thấy thay đổi";
                        return Page();
                    }
                    else
                    {
                        TempData["errorMessage"] = "Hệ thống không thể ghi lại bản sửa của bạn! Hãy thử lại hoặc sửa lại sau ít phút. Chúng tôi đang sửa nó `(*>﹏<*)′`(*>﹏<*)′";
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Hệ thống không thể ghi lại bản sửa của bạn! Hãy thử lại hoặc sửa lại sau ít phút. Chúng tôi đang sửa nó `(*>﹏<*)′`(*>﹏<*)′" + ex.Message;
                return Page();

            }

        }
    }
}
