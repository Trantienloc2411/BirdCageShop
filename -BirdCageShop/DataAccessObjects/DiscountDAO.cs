using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class DiscountDAO
    {
        private CageShopUni_alaContext _context;
        public DiscountDAO()
        {
            _context = new CageShopUni_alaContext();
        }

        public IEnumerable<Discount> GetAll()
        {
            return _context.Discounts.ToList();
        }
    }
}
