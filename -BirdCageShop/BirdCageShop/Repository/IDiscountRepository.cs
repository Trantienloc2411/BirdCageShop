using BusinessObjects.Models;

namespace Repository
{
    public interface IDiscountRepository
    {
        IEnumerable<Discount> GetAll();
    }
}