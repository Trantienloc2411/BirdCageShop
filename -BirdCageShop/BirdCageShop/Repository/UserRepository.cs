﻿using BusinessObjects.Models;
using DataAccessObjects;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDAO _dao;

        public UserRepository()
        {
            _dao = new UserDAO();
        }
        public void Add(User user) => _dao.Add(user);
        public void Delete(int id) => _dao.Delete(id);
        public User GetUserById(int id) => _dao.GetUserById(id);
        public List<User> GetAllUser() => _dao.GetAll();
        public User GetUserByEmail(string email) => _dao.getUserByEmail(email);
        public List<User> GetListUserByName(string name) => _dao.GetListUserByName(name);
        public int Update(User user) => _dao.Update(user);
        public User checkUserLogin(string email, string password) => _dao.checkUserLogin(email, password);
    }
}
