using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _dao;

        public UserRepository()
        {
            _dao = new UserDAO();
        }
        public void Add(User user) => _dao.Add(user);
        public void Delete(int id) => _dao.Delete(id);
        public User GetUserById(int id) => _dao.GetUserById(id);
        public string GetUserImage(int Id) => _dao.getUserImage(Id);
        public List<User> GetAllUser() => _dao.GetAll();
        public List<User> getUserPages(int pageIndex, int pageSize) => _dao.getUserPages(pageIndex, pageSize);
        public int getTotalUserPages() => _dao.getTotalUserPages();
        public User GetUserByEmail(string email) => _dao.getUserByEmail(email);
        public List<User> GetListUserByName(string name) => _dao.GetListUserByName(name);
        public int Update(User user) => _dao.Update(user);
        public User checkUserLogin(string email, string password) => _dao.checkUserLogin(email, password);
        public List<Role> GetUserRole() => _dao.GetRoles();

        public bool isEmailexisted(string email) => _dao.isEmailExisted(email);
        public int UpdateUserProfile(User User) => _dao.UpdateUserProfile(User);
        public bool IsEmailExistedExceptEmailCurrent(string emailCheck, string emailCurrent) => _dao.IsEmailExistedExceptEmailCurrent(emailCheck, emailCurrent);
        public int AddProductToCart(int userID, int productID, int quantity) => _dao.AddProductToCart(userID, productID, quantity);
        public List<OrderDetail> getListcartByUserID(int userID) => _dao.getListcartByUserID(userID);
        public Order getOrderPrice_Cart_ByUserID(int userID) => _dao.getOrderPrice_Cart_ByUserID(userID);
        public List<Order> getOrderByUser(int userID) => _dao.getOrderByUser(userID);
        public int DeleteProductInCartByProductID(int userID, int productID) => _dao.DeleteProductInCartByProductID(userID, productID);

        public int UpdateProductInCartByProductID(int userID, int productID, int quantity) => _dao.UpdateProductInCartByProductID(userID, productID, quantity);

        public int UpdateUserPassword(User u) => _dao.UpdateUserPassword(u);
        public int ManagerUpdate(User User) => _dao.ManagerUpdate(User);
        public User GetUserByIdWithoutPassword(int Id) => _dao.GetUserByIdWithoutPassword(Id);


    }
}
