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
    }
}
