﻿using BusinessObjects.Models;

namespace Repository
{
    public interface IFeedbackRepository
    {
        void Add(Feedback fb);
        void Delete(int fbId);
        IEnumerable<Feedback> GetAll();
        Feedback GetFeedbackrById(int fbId);
        void Update(Feedback fb);
        List<Order> GetOrders();
        List<User> GetUsers();
    }
}