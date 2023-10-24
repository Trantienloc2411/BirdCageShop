using BusinessObjects.Models;
using DataAccessObjects;


namespace Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private CategoryDAO _dao;
        public CategoryRepository()
        {
            _dao = new CategoryDAO();
        }
        public IEnumerable<Category> GetAll() => _dao.GetAll();
    }
}
