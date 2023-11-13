using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class FeedbackDAO
    {
        private readonly CageShopUni_alaContext _db;

        public FeedbackDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public Feedback GetFeedbackrById(int fbId)
        {
            return _db.Feedbacks.FirstOrDefault(o => o.FeedbackId == fbId);
        }
        public void Add(Feedback fb)
        {
            _db.Add(fb);
            _db.SaveChanges();
        }
        public void Update(Feedback fb)
        {
            var o = GetFeedbackrById(fb.FeedbackId);
            if (o != null)
            {
                o.FeedBackName = fb.FeedBackName;
                o.FeedBackContent = fb.FeedBackContent;
                o.Rating = fb.Rating;

                _db.SaveChanges();
            }
        }
        public void Delete(int fbId)
        {
            var o = GetFeedbackrById(fbId);
            if (o != null)
            {
                _db.Feedbacks.Remove(o);
                _db.SaveChanges();
            }
        }
        public IEnumerable<Feedback> GetAll()
        {
            return _db.Feedbacks.ToList();
        }
        public List<Order> GetOrders()
        {
            return _db.Orders.ToList();
        }
        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }
    }
}
