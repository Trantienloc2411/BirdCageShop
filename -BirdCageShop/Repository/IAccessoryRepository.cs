using BusinessObjects.Models;

namespace Repository
{
    public interface IAccessoryRepository
    {
        void Add(Accessory accessory);
        void Delete(int id);
        Accessory GetAccessoryById(int id);
        List<Accessory> GetAccessoryByName(string name);
        List<Accessory> getAccessoryPages(int pageIndex, int pageSize);
        IEnumerable<Accessory> GetAll();
        List<Category> GetCategories();
        List<Discount> GetDiscounts();
        int getTotalAccessoryPages();
        void Update(Accessory accessory);
    }
}