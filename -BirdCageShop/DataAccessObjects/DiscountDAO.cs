using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class DiscountDAO
    {
        private CageShopUni_alaContext _db;
        public DiscountDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public IEnumerable<Discount> GetAll()
        {
            return _db.Discounts.ToList();
        }
        public Discount GetDiscountById(int disId)
        {
            return _db.Discounts.FirstOrDefault(o => o.DiscountId == disId);
        }
        public void Add(Discount dis)
        {
            _db.Add(dis);
            _db.SaveChanges();
        }
        public void Update(Discount dis)
        {
            var o = GetDiscountById(dis.DiscountId);
            if (o != null)
            {
                o.DiscountName = dis.DiscountName;
                o.DiscountStart = dis.DiscountStart;
                o.DiscountFinish = dis.DiscountFinish;
                o.Discount1 = dis.Discount1;
                o.DiscountStatus = dis.DiscountStatus;

                _db.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var o = GetDiscountById(id);
            if (o != null)
            {
                _db.Discounts.Remove(o);
                _db.SaveChanges();
            }
        }
    }
}
