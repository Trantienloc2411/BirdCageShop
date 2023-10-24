using BusinessObjects.Models;
using System.Reflection;

namespace Repository
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        List<Category> GetCategories();
        List<Discount> GetDiscounts();
        Product GetProductById(int id);
        List<Product> GetListProBouByName(string name);
        void Update(Product product);
        Product getProductDetail(int id);
        Tuple<int, int> getFeedback(int id);

    }
}