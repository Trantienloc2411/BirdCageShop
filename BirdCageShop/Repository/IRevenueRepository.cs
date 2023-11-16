using BusinessObjects.Models;

namespace Repository
{
    public interface IRevenueRepository
    {
        IEnumerable<Order> GetAll();
        List<User> GetUsers();
        string FindUserNameByUserId(int? userId);
    }
}