using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

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

        public List<FeedbackItem> getListFeedbackByProductID(int productID)
        {
            
            var result = from f in _db.Feedbacks
                         join o in _db.Orders on f.OrderId equals o.OrderId
                         join u in _db.Users on f.UserId equals u.UserId
                         join od in _db.OrderDetails on o.OrderId equals od.OrderId
                         join p in _db.Products on od.CageId equals p.CageId
                         where p.CageId == productID
                         select new FeedbackItem { UserName = u.UserName, FeedbackName = f.FeedBackName, FeedbackContent =  f.FeedBackContent, rating = (double)f.Rating, UserIMG = u.UserImg };
            return result.ToList();
        }
        public List<FeedbackItem> getListFeedbackByAccessoryID(int productID)
        {
            var result = from f in _db.Feedbacks
                         join o in _db.Orders on f.OrderId equals o.OrderId
                         join u in _db.Users on f.UserId equals u.UserId
                         join od in _db.OrderDetails on o.OrderId equals od.OrderId
                         join p in _db.Accessories on od.AccessoryId equals p.AccessoryId
                         where p.AccessoryId == productID
                         select new FeedbackItem { UserName = u.UserName, FeedbackName = f.FeedBackName, FeedbackContent = f.FeedBackContent, rating = (double)f.Rating, UserIMG = u.UserImg };
            return result.ToList();
        }
    }
}
