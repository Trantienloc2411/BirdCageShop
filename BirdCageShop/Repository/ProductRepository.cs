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

        public Product getProductDetail(int id) => _dao.getProductDetail(id);

        public Tuple<int, int> getFeedback(int id) => _dao.getRatingProduct(id);

        public List<Product> getListProductTrendingForUser() => _dao.getListProductTrendingForUser();

        public List<Product> getListProductForUser() => _dao.getListProductForUser();
        public List<Product> getProductPagesForUser(int pageIndex, int pageSize) => _dao.getProductPagesForUser(pageIndex, pageSize);

        public List<Accessory> GetAccessories() => _dao.GetAccessories();

        public Accessory getDetailAccessoryByID(int accessoryID) => _dao.getDetailAccessoryByID(accessoryID);

        public List<Accessory> getAccessoryPages(int pageIndex, int pageSize) => _dao.getAccessoryPages(pageIndex, pageSize);

        public int getTotalAccessoryPages() => _dao.getTotalAccessoryPages();

        List<Accessory> IProductRepository.GetAccessoryByName(string name) => _dao.GetAccessoryByName((string)name);

        public Tuple<int, int> getRatingAccessory(int accessoryID) => _dao.getRatingAccessory(accessoryID);
        public List<Product> comparisionProduct(int prod1, int prod2) => _dao.comparisionProduct(prod1, prod2);
        public int AddCustomizeCage(Product p) => _dao.AddCustomizeCage((Product)p);

        public Product GetProduct(int id) => _dao.GetProduct(id);
    }
}
