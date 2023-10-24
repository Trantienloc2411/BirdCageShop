using BusinessObjects.Models;

namespace Repository
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}