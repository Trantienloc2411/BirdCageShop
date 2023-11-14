using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class RevenueRepository : IRevenueRepository
    {
        private readonly RevenueDAO _dao;

        public RevenueRepository()
        {
            _dao = new RevenueDAO();
        }
        public IEnumerable<Order> GetAll() => _dao.GetAll();
        public List<User> GetUsers() => _dao.GetUsers();
        public string FindUserNameByUserId(int? userId) => _dao.FindUserNameByUserId(userId);
    }
}
