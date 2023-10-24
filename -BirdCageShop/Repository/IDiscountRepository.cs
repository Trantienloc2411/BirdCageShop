using BusinessObjects.Models;

namespace Repository
{
    public interface IDiscountRepository
    {
        IEnumerable<Discount> GetAll();
        Discount GetDiscountById(int disId);
        void Add(Discount order);
        void Update(Discount dis);
        void Delete(int orderId);
    }
}