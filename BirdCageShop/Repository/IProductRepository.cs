using BusinessObjects.Models;

namespace Repository
{
    public interface IProductRepository
    {
        void Add(Product product);
        void Delete(int id);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllShow();
        IEnumerable<Product> GetAllHidden();
        IEnumerable<Product> GetAllCustomized();
        List<Category> GetCategories();
        List<Discount> GetDiscounts();
        Product GetProductById(int id);
        List<Product> GetListProductByName(string name);
        void Update(Product product);
        Product getProductDetail(int id);
        Tuple<int, int> getFeedback(int id);
        List<Product> getListProductTrendingForUser();
        List<Product> getListProductForUser();
        List<Product> getProductPagesForUser(int pageIndex, int pageSize);
        List<Accessory> GetAccessories();
        List<Product> getProductPages(int pageIndex, int pageSize);
        List<Product> getProductShowPages(int pageIndex, int pageSize);
        List<Product> getProductHiddenPages(int pageIndex, int pageSize);
        List<Product> getProductCustomizedPages(int pageIndex, int pageSize);
        int getTotalProductPages();
        int getTotalProductShowPages();
        public int getTotalProductHiddenPages();
        public int getTotalProductCustomizedPages();


        Accessory getDetailAccessoryByID(int accessoryID);
        List<Accessory> getAccessoryPages(int pageIndex, int pageSize);
        int getTotalAccessoryPages();
        List<Accessory> GetAccessoryByName(string name);
        Tuple<int, int> getRatingAccessory(int accessoryID);
        List<Product> comparisionProduct(int prod1, int prod2);

        int AddCustomizeCage(Product p);
        Product GetProduct(int id);
    }
}