using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class UserDAO
    {
        private readonly CageShopUni_alaContext _dbContext;

        public UserDAO()
        {
            _dbContext = new CageShopUni_alaContext();
        }

        public User getUserByEmail(string email)
        {
            return _dbContext.Users.FirstOrDefault(c => c.Email == email);
        }

        public string getUserImage(int Id)
        {
            var userImg = GetUserById(Id);
            return userImg?.UserImg ?? null;
        }

        public User GetUserById(int Id)
        {
            return _dbContext.Users.FirstOrDefault(c => c.UserId == Id);
        }
        public List<User> GetListUserByName(string name)
        {
            return _dbContext.Users.Where(c => c.UserName.Equals(name)).ToList();
        }

        public void Add(User User)
        {
            _dbContext.Add(User);
            _dbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _dbContext.Users.ToList();
        }

        public int Update(User User)
        {
            var user = GetUserById(User.UserId);
            if (user != null)
            {
                //cus.Email = User.Email;
                user.UserName = User.UserName;
                user.Phone = User.Phone;
                user.Address = User.Address;
                user.UserImg = User.UserImg;
                user.DoB = User.DoB;

                return _dbContext.SaveChanges();
            }
            return 0;
        }
        public int ManagerUpdate(User User)
        {
            var user = GetUserById(User.UserId);
            if (user != null)
            {

                user.Status = User.Status;


                return _dbContext.SaveChanges();
            }
            return 0;
        }

        public void Delete(int cusID)
        {
            var flag = GetUserById(cusID);
            if (flag != null)
            {
                _dbContext.Users.Remove(flag);
                _dbContext.SaveChanges();
            }
        }
        // check User login
        public User checkUserLogin(string email, string password)
        {
            return _dbContext.Users.FirstOrDefault(c => c.Email == email && c.UserPassword == password);
        }

        public List<Role> GetRoles()
        {
            return _dbContext.Roles.ToList();
        }
    }
}
