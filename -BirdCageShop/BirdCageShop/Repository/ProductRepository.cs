using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDAO _dao;

        public ProductRepository()
        {
            _dao = new ProductDAO();
        }
        public void Add(Product product) => _dao.Add(product);

        public void Delete(int id) => _dao.Delete(id);

        public IEnumerable<Product> GetAll() => _dao.GetAll();

        public List<Category> GetCategories() => _dao.GetCategories();

        public Product GetProductById(int id) => _dao.GetProductById(id);

        public List<Product> GetListProductByName(string name) => _dao.GetProductByName(name);

        public List<Discount> GetDiscounts() => _dao.GetDiscounts();

        public void Update(Product product) => _dao.Update(product);

        public List<Product> getProductListForUser() => _dao.getListProductForUser();
    }
}
