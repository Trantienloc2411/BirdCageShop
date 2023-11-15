using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.Net.Mail;
using System.Net;
using MailKit.Security;
using MimeKit;
using static System.Net.WebRequestMethods;
using BusinessObjects;
using MailKit.Net.Smtp;

namespace BirdCageShop.Pages.Login
{
    public class RecoverModel : PageModel
    {
        private static readonly MailKit.Net.Smtp.SmtpClient smtpClient = new MailKit.Net.Smtp.SmtpClient();
        [BindProperty]
        public string EmailRecover { get;set; }
        private IUserRepository _user;
        private readonly IConfiguration _config;
        public RecoverModel(IConfiguration config)
        {
            _user = new UserRepository();
            _config = config;
        }
        public void OnGet() 
        {
            Page();
        }

        public async Task<IActionResult> OnPostForgetPassword()
        {
            if(EmailRecover != null)
            {
                if(_user.isEmailexisted(EmailRecover))
                {
                    ///TODO: Send Email Check The code is == our system

                    int otp = Utility.codeRecovery();
                    MimeMessage message = new MimeMessage();
                    message.From.Add(new MailboxAddress("CageShopWing", _config.GetSection("EmailUserName").Value));
                    message.To.Add(MailboxAddress.Parse(EmailRecover)); // Receiver's email
                    message.Subject = "Khôi phục mật khẩu - CageShopWing";

                    message.Body = new TextPart("plain")
                    {
                        Text = $"Bạn đã gửi yêu khầu khôi phục mật khẩu. Mã xác thực là : {otp}. Nếu không phải bạn gửi yêu cầu hãy bỏ qua email này! Xin cảm ơn"
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
                        await smtpClient.DisconnectAsync(true);
                        return Page();
                    }

                    HttpContext.Session.SetString("email", EmailRecover);
                    HttpContext.Session.SetInt32("OTP", otp);
                    TempData["successMessage"] = "Mã OTP đã được gửi tới email. Hãy kiểm tra ở Hòm thư hoặc thư rác.";
                    return RedirectToPage("./ConfirmRecover");
                }
                else
                {
                    TempData["errorMessage"] = "Email bạn nhập không tồn tại!";
                    return Page();
                }
            }
            else
            {
                TempData["errorMessage"] = "Email bạn nhập không hợp lệ hoặc đang bỏ trống!";
                return Page();
            }
        }


    }
}
