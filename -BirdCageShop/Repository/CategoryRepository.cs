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
        public Category GetCategoryById(int disId) => _dao.GetCategoryById(disId);
        public void Add(Category cat) => _dao.Add(cat);
        public void Update(Category cat) => _dao.Update(cat);
        public void Delete(int id) => _dao.Delete(id);
    }
}
