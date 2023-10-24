using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class CategoryDAO
    {
        private CageShopUni_alaContext _db;
        public CategoryDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public IEnumerable<Category> GetAll()
        {
            return _db.Categories.ToList();
        }
        public Category GetCategoryById(int disId)
        {
            return _db.Categories.FirstOrDefault(o => o.CategoryId == disId);
        }
        public void Add(Category cat)
        {
            _db.Add(cat);
            _db.SaveChanges();
        }
        public void Update(Category cat)
        {
            var o = GetCategoryById(cat.CategoryId);
            if (o != null)
            {
                o.CategoryName = cat.CategoryName;
                o.Description = cat.Description;

                _db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var o = GetCategoryById(id);
            if (o != null)
            {
                _db.Categories.Remove(o);
                _db.SaveChanges();
            }
        }
    }
}
