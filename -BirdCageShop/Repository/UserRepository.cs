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
        public byte[] GetUserImage(int Id) => _dao.getUserImage(Id);
        public List<User> GetAllUser() => _dao.GetAll();
        public User GetUserByEmail(string email) => _dao.getUserByEmail(email);
        public List<User> GetListUserByName(string name) => _dao.GetListUserByName(name);
        public int Update(User user) => _dao.Update(user);
        public User checkUserLogin(string email, string password) => _dao.checkUserLogin(email, password);
        public List<Role> GetUserRole() => _dao.GetRoles();
        public bool isEmailexisted(string email) => _dao.isEmailExisted(email);
        public int UpdateUserProfile(User User) => _dao.UpdateUserProfile(User);   
        public bool IsEmailExistedExceptEmailCurrent(string emailCheck, string emailCurrent) => _dao.IsEmailExistedExceptEmailCurrent(emailCheck, emailCurrent);

        public int AddProductToCart(int userID, int productID, int quantity) => _dao.AddProductToCart(userID, productID, quantity);

    }
}
