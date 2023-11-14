using BusinessObjects.Models;

namespace Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
        Category GetCategoryById(int disId);
        void Add(Category cat);
        void Update(Category cat);
        public void Delete(int id);
    }
}