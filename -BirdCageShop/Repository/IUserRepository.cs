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
        int Update(User user);
        bool isEmailexisted(string email);
    }
}