using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private readonly CageShopUni_alaContext _db;

        public ProductDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public Product GetProductById(int id)
        {
            return _db.Products.FirstOrDefault(p => p.CageId == id);
        }

        public List<Product> GetProductByName(string name)
        {
            return _db.Products.Where(p => p.CageName.Contains(name)).ToList();
        }

        public void Add(Product product)
        {
            product.CageStatus = 1;
            _db.Add(product);
            _db.SaveChanges();
        }

        public void Update(Product product)
        {
            var pro = GetProductById(product.CageId);
            if (pro != null)
            {
                pro.CageName = product.CageName;
                pro.Category = product.Category;
                pro.Quantity = product.Quantity;
                pro.Price = product.Price;
                pro.Discount = product.Discount;
                pro.CageImg = product.CageImg;
                pro.Material = product.Material;
                pro.Size = product.Size;
                pro.Bar = product.Bar;
                pro.Description = product.Description;
                pro.CageStatus = product.CageStatus;

                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var pro = GetProductById(id);
            var od = _db.OrderDetails.FirstOrDefault(od => od.CageId == id);
            if (pro != null && od == null)
            {
                _db.Products.Remove(pro);
                _db.SaveChanges();
            }
            else if (pro != null)
            {
                pro.CageStatus = 0;
                _db.SaveChanges();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _db.Products.Where(p => p.CageStatus == 1).ToList();
        }
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public List<Discount> GetDiscounts()
        {
            return _db.Discounts.ToList();
        }
        public List<Product> getProductPages(int pageIndex, int pageSize)
        {
            return _db.Products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public int getTotalProductPages()
        {
            return _db.Products.Count();
        }

        //public void Upload(int cageId, IFormFile imageFile)
        //{
        //    var cage = GetProductById(cageId);

        //    if (cage != null && imageFile != null && imageFile.Length > 0)
        //    {
        //        using (BinaryReader reader = new BinaryReader(imageFile.OpenReadStream()))
        //        {
        //            cage.CageImg = reader.ReadBytes((int)imageFile.Length);
        //            _db.SaveChanges();
        //        }
        //    }
        //}
        public List<Product> getListProductForUser()
        {
            return _db.Products
                       .Where(p => p.CageStatus.Equals(1))
                       .Include(p => p.Discount)
                       .ToList();
        }

        public List<Product> getListProductTrendingForUser()
        {
            var cageIds = (from p in _db.Products
                           join od in _db.OrderDetails on p.CageId equals od.CageId
                           join o in _db.Orders on od.OrderId equals o.OrderId
                           join f in _db.Feedbacks on o.OrderId equals f.OrderId
                           group f by p.CageId into g
                           select new { CageId = g.Key, AverageRating = g.Average(x => x.Rating) })
                          .OrderByDescending(x => x.AverageRating)
                          .Take(4)
                          .Select(x => x.CageId)
                          .ToList();

            var products = _db.Products.Where(p => cageIds.Contains(p.CageId)).ToList();
            return products.ToList();
        }

        public Product getProductDetail(int id)
        {
            return _db.Products.FirstOrDefault(p => p.CageId == id && p.CageStatus == 1);
        }

        public Tuple<int, int> getRatingProduct(int productID)
        {
            var countFeedback = (from p in _db.Products
                                 join od in _db.OrderDetails on p.CageId equals od.CageId
                                 join o in _db.Orders on od.OrderId equals o.OrderId
                                 join fed in _db.Feedbacks on o.OrderId equals fed.OrderId
                                 where p.CageId == productID
                                 select fed.FeedbackId).Count();
            var avgFeedback = (from p in _db.Products
                               join od in _db.OrderDetails on p.CageId equals od.CageId
                               join o in _db.Orders on od.OrderId equals o.OrderId
                               join fed in _db.Feedbacks on o.OrderId equals fed.OrderId
                               where p.CageId == productID
                               select fed.Rating).Average();
            if (countFeedback > 0)
            {
                return Tuple.Create(countFeedback, (int)avgFeedback);
            }
            else return Tuple.Create(0, 0);

        }

    }
}
