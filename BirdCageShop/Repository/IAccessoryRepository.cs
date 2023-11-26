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
        List<Accessory> getAccessoryShowPages(int pageIndex, int pageSize);
        List<Accessory> getAccessoryHiddenPages(int pageIndex, int pageSize);
        IEnumerable<Accessory> GetAll();
        IEnumerable<Accessory> GetAllShow();
        IEnumerable<Accessory> GetAllHidden();
        List<Category> GetCategories();
        List<Discount> GetDiscounts();
        int getTotalAccessoryPages();
        int getTotalAccessoryShowPages();
        int getTotalAccessoryHiddenPages();
        void Update(Accessory accessory);
    }
}