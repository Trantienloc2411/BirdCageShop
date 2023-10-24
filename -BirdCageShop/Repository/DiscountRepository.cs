using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class DiscountRepository : IDiscountRepository
    {
        private DiscountDAO _dao;
        public DiscountRepository()
        {
            _dao = new DiscountDAO();
        }
        public IEnumerable<Discount> GetAll() => _dao.GetAll();
    }
}
