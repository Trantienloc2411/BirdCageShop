using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class CategoryDAO
    {
        private CageShopUni_alaContext _context;
        public CategoryDAO()
        {
            _context = new CageShopUni_alaContext();
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }
    }
}
