using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FeedbackDAO _dao;

        public FeedbackRepository()
        {
            _dao = new FeedbackDAO();
        }

        public Feedback GetFeedbackrById(int fbId) => _dao.GetFeedbackrById(fbId);
        public void Add(Feedback fb) => _dao.Add(fb);
        public void Update(Feedback fb) => _dao.Update(fb);
        public void Delete(int fbId) => _dao.Delete(fbId);
        public IEnumerable<Feedback> GetAll() => _dao.GetAll();
        public List<Order> GetOrders() => _dao.GetOrders();
        public List<User> GetUsers() => _dao.GetUsers();
        public List<FeedbackItem> getListFeedbackByProductID(int productID) => _dao.getListFeedbackByProductID(productID);
        public List<FeedbackItem> getListFeedbackByAccessoryID(int productID) => _dao.getListFeedbackByAccessoryID(productID);

    }
}
