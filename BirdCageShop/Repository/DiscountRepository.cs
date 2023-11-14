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
        public Discount GetDiscountById(int disId) => _dao.GetDiscountById(disId);
        public void Add(Discount order) => _dao.Add(order);
        public void Update(Discount dis) => _dao.Update(dis);
        public void Delete(int orderId) => _dao.Delete(orderId);
        public void AutoUpdateDiscount() => _dao.AutoUpdateDiscount();
    }
}
