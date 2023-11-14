using BusinessObjects.Models;

namespace Repository
{
    public interface IUserRepository
    {
        void Add(User user);
        User checkUserLogin(string email, string password);
        void Delete(int id);
        List<User> GetAllUser();
        List<User> GetListUserByName(string name);
        User GetUserByEmail(string email);
        User GetUserById(int id);
        string GetUserImage(int Id);
        int Update(User user);
        List<Role> GetUserRole();
        bool isEmailexisted(string email);
        bool IsEmailExistedExceptEmailCurrent(string emailCheck, string emailCurrent);
        int UpdateUserProfile(User User);
        int AddProductToCart(int userID, int productID, int quantity);
        List<OrderDetail> getListcartByUserID(int userID);
        Order getOrderPrice_Cart_ByUserID(int userID);
        List<Order> getOrderByUser(int userID);
        int DeleteProductInCartByProductID(int userID, int productID);
        int UpdateProductInCartByProductID(int userID, int productID, int quantity);

        int ManagerUpdate(User User);


    }
}