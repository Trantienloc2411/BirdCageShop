using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class DiscountDAO
    {
        private DateTime today;
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
        private List<Discount> discountList = new List<Discount>();
        public void AutoUpdateDiscount()
        {
            DateTime today = DateTime.Today;
            discountList = GetAll().ToList();
            //get list DiscountStatus == Not Start
            var discountTimeNotStartList = discountList.Where(o => o.DiscountStatus == "Not Start"); //TODO: PROBLEM!!!!
            //get list DiscountStatus == Ongoing
            var discountTimeOngoingList = discountList.Where(o => o.DiscountStatus == "Ongoing");
            foreach(var item in discountTimeNotStartList)
            {
                if(item.DiscountStart <= today)
                {
                    item.DiscountStatus = "Ongoing";
                    _db.SaveChanges();
                }
            }
            foreach(var item in discountTimeOngoingList)
            {
                if(item.DiscountFinish <= today)
                {
                    item.DiscountStatus = "Ended";
                    _db.SaveChanges();
                }
            }
        }
    }
}
