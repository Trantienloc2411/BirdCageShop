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
    }
}