using BusinessObjects.Models;

namespace Repository
{
    public interface IRevenueRepository
    {
        IEnumerable<Order> GetAll();
    }
}