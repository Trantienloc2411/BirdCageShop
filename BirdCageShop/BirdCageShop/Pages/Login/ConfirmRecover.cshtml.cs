using BusinessObjects;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Exchange.WebServices.Data;
using MimeKit;
using Repository;
using static System.Net.WebRequestMethods;

namespace BirdCageShop.Pages.Login
{
    public class ConfirmRecoverModel : PageModel
    {
        private static readonly MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
        public string EmailRecover { get; set; }
        [BindProperty]
        public string OTP { get; set; }
        public int compareOTP { get; set; }
        private IUserRepository _user;
        private readonly IConfiguration _config;
        public ConfirmRecoverModel(IConfiguration config)
        {
            _user = new UserRepository();
            _config = config;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostConfirmOTP()
        {
            EmailRecover = HttpContext.Session.GetString("email");
            compareOTP = (int)HttpContext.Session.GetInt32("OTP");
            int otpS = 0;
            if (!int.TryParse(OTP, out otpS))
            {
                otpS = 0;
            }
            
            if (otpS == compareOTP)
            {
                var user = _user.GetUserByEmail(EmailRecover);
                if (user == null)
                {
                    TempData["errorMessage"] = "Đã xảy ra lỗi. Không tìm thấy người dùng";
                    return RedirectToPage("./Index");
                }
                else
                {
                    string newPassword = Utility.passwordRecovery();
                    user.UserPassword = newPassword;
                    if (_user.UpdateUserPassword(user) != 0)
                    {
                        MimeMessage message = new MimeMessage();
                        message.From.Add(new MailboxAddress("CageShopWing", _config.GetSection("EmailUserName").Value));
                        message.To.Add(new MailboxAddress("", EmailRecover)); // Receiver's email
                        message.Subject = "CageShopWing - Mật khẩu đã được thay đổi";

                        message.Body = new TextPart("plain")
                        {
                            Text = $"Mật khẩu của bạn đã được thay đổi. Mật khẩu mới là:  {newPassword}. Hãy vui lòng truy cập tài khoản để thay đổi lại mật khẩu."
                        };

                        try
                        {
                            await smtpClient.ConnectAsync(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls); // Use the appropriate SMTP server and port
                            await smtpClient.AuthenticateAsync(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value); // Your SMTP credentials
                            await smtpClient.SendAsync(message);
                            await smtpClient.DisconnectAsync(true);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error sending email: {ex.Message}");
                            TempData["errorMessage"] = "Đã xảy ra lỗi :" + ex.Message;
                            return Page();
                        }
                        TempData["successMessage"] = "Mật khẩu mới đã được gửi tới email. Hãy kiểm tra ở Hòm thư hoặc thư rác.";
                        HttpContext.Session.SetString("email", "");
                        HttpContext.Session.SetInt32("OTP", 0);
                        return RedirectToPage("./Index");
                    }
                    else
                    {
                        TempData["errorMessage"] = "Lưu mật khẩu mới thất bại! Không thể khôi phục";
                        return RedirectToPage("./Index");
                    }
                }

            }
            else
            {
                TempData["errorMessage"] = "Mã OTP không khớp!";
                OnGet();
                return Page();
            }
        }


    }
}
