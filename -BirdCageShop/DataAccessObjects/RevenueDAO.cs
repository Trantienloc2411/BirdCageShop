using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class RevenueDAO
    {
        private readonly CageShopUni_alaContext _db;

        public RevenueDAO()
        {
            _db = new CageShopUni_alaContext();
        }
        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.ToList();
        }
        public List<User> GetUsers()
        {
            return _db.Users.ToList();
        }
        public string FindUserNameByUserId(int? userId)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserId == userId);

            if (user != null)
            {
                return user.UserName;
            }

            return "User not found"; // or throw an exception, depending on your requirements
        }
    }
}
