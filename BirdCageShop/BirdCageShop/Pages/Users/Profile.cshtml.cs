using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Exchange.WebServices.Data;
using Repository;

namespace BirdCageShop.Pages.Users
{
    public class ProfileModel : PageModel
    {
        private IUserRepository userRepository;
        private IOrderRepository _orderRepo;
        private IOrderDetailRepository _orderDetailRepo;
        private IProductRepository productRepository;
        public List<OrderDetail> GetOrderDetails { get; set; }
        public List<Order> orderPending { get; set; }
        public List<Order> orderDelivering { get; set; }
        public List<Order> orderDelivered { get; set; }
        public List<Order> orderCancel{ get; set; }
        public List<Order> order { get; set; }
        public Feedback fb;
        [BindProperty]
        public int OrderID { get; set; }

        public int countOrderDetail { get; set; }
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
            _orderRepo = new OrderRepository();
            _orderDetailRepo = new OrderDetailRepository();
            productRepository = new ProductRepository();
            fb = new Feedback();
        }
        public IActionResult OnGet()
        {
            try
            {
                #region Handle if user not authorize can not access this page
                #endregion
                int userID = HttpContext.Session.GetInt32("userID").GetValueOrDefault(-1);
                if (userID == -1)
                {
                    TempData["errorMessage"] = "Hãy xác thực để xem thông tin của mình nhé";
                    return RedirectToPage("../Login/Index");
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
                    if(user.DoB != null)
                    {
                        dob = (DateTime)user.DoB;
                    }
                    else
                    {
                        dob = DateTime.Now; 
                    }

                    Phone = user.Phone;

                    
                    ///Part of OrderList
                    var orderList = _orderRepo.orderListIncludeOrderDetail(userID).OrderByDescending(u => u.OrderDate);
                    if (orderList != null)
                    {
                        order = orderList.ToList();
                        orderPending = orderList.Where(u => u.OrderStatus == "Pending").ToList() ;
                        orderCancel = orderList.Where(u => u.OrderStatus == "Cancelled").ToList();
                        orderDelivering = orderList.Where(u => u.OrderStatus == "Delivering").ToList();
                        orderDelivered = orderList.Where(u => u.OrderStatus == "Delivered").ToList();
                    }
                    else
                    {
                        orderPending = new List<Order>();
                    }

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
        public IActionResult OnPostCancelTheOrder()
        {
            int OrderID = int.Parse(Request.Form["orderId"].ToString());
            string note = Request.Form["cancelOptions"].ToString(); 
            var order = _orderRepo.getOrderByOrderID(OrderID);
            if (order != null)
            {
                order.OrderStatus = "Canceled";
                order.Note = note;
                order.OrderEst = "test01";
                _orderRepo.Update(order);
                TempData["successMessage"] = "Huỷ đơn hàng thành công! Hãy chờ thông tin từ của hàng";
                OnGet();
                return RedirectToPage("../Index");
            }
            else
            {
                TempData["errorMessage"] = "Huỷ đơn hàng không thành công!";
                OnGet();
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
                    OnGet();
                    return Page();
                }
                else if (UserName == null || UserName == null || Phone == null || Address == null)
                {
                    TempData["errorMessage"] = "Tất cả các ô không được để trống";
                    OnGet();
                    return Page();
                }
                else if (Password.Length < 7 || Password == null || Password.Length > 32)
                {
                    TempData["errorMessage"] = "Mật khẩu không hợp lệ! Mật khẩu phải từ 8 đến 32 kí tự";
                    OnGet();
                    return Page();
                }
                else if(Password == null || Password.Count() == 0)
                {
                    TempData["errorMessage"] = "Mật khẩu mới đang để trống";
                    OnGet();
                    return Page();
                }
                else if (Password != PasswordRepeat || PasswordRepeat == null)

                {
                    TempData["errorMessage"] = "Mật khẩu và mật khẩu lặp lại không khớp! Thử lại";
                    OnGet();
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
                    if(Password != null)
                    {
                        user.UserPassword = Password;
                    }
                    int success = userRepository.UpdateUserProfile(user);
                    if(success != 0)
                    {
                        TempData["successMessage"] = "Thông tin được cập nhật thành công! Hãy tải lại trang để thấy thay đổi";
                        OnGet();
                        return Page();
                    }
                    else
                    {
                        TempData["errorMessage"] = "Hệ thống không thể ghi lại bản sửa của bạn! Hãy thử lại hoặc sửa lại sau ít phút. Chúng tôi đang sửa nó `(*>﹏<*)′`(*>﹏<*)′";
                        OnGet();
                        return Page();
                    }
                }
            }
            catch (Exception ex)
            {
                TempData["errorMessage"] = "Hệ thống không thể ghi lại bản sửa của bạn! Hãy thử lại hoặc sửa lại sau ít phút. Chúng tôi đang sửa nó `(*>﹏<*)′`(*>﹏<*)′" + ex.Message;
                OnGet();
                return Page();

            }

        }

        ///TODO: This function can not pass from View to CodeBEHinde
        /// <summary>
        /// Update Order When user cancel the Order 
        /// </summary>
        /// <param name="OrderID"></param>

        public int countProductInOrder(int orderID)
        {   
            return _orderDetailRepo.getQuantityProductByOrderID(orderID);
        }
        public List<OrderDetail> GetOrderDetailsByOrderID(int orderID)
        {
            return _orderDetailRepo.getOrderDetailByOrderID(orderID);
        }
        public Product getProductNameByProductID(int productID)
        {
            return productRepository.GetProductById(productID);
        }
        public Accessory getAccessoryNameByAccessoryID(int accessoryID)
        {
            return productRepository.getDetailAccessoryByID(accessoryID);
        }


    }
}
