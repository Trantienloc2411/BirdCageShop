using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class RevenueDAO
    {
        private readonly CageShopUni_alaContext _db;

        public RevenueDAO()
        {
            _db = new CageShopUni_alaContext();
        }
        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
    }
}
