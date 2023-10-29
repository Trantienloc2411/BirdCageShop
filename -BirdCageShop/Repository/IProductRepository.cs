using BusinessObjects.Models;

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
        List<Product> GetListProductByName(string name);
        void Update(Product product);
        List<Product> getProductPages(int pageIndex, int pageSize);
        int getTotalProductPages();
        //void Upload(int cageId, IFormFile imageFile);
    }
}