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
        public List<Product> getProductPages(int pageIndex, int pageSize) => _dao.getProductPages(pageIndex, pageSize);
        public int getTotalProductPages() => _dao.getTotalProductPages();

        //public void Upload(int cageId, IFormFile imageFile) => _dao.Upload(cageId, imageFile);
        public List<Product> getProductListForUser() => _dao.getListProductForUser();

        public Product getProductDetail(int id) => _dao.getProductDetail(id);

        public Tuple<int, int> getFeedback(int id) => _dao.getRatingProduct(id);

        public List<Product> getListProductTrendingForUser() => _dao.getListProductTrendingForUser();


    }
}
