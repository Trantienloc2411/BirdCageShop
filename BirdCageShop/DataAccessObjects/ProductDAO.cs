using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessObjects
{
    public class ProductDAO
    {
        private readonly CageShopUni_alaContext _db;
        private List<Product> _products;
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
            return _db.Products.ToList();
        }
        public IEnumerable<Product> GetAllShow()
        {
            return _db.Products.Where(u => u.CageStatus == 1).ToList();
        }
        public IEnumerable<Product> GetAllHidden()
        {
            return _db.Products.Where(u => u.CageStatus == 0).ToList();
        }
        public IEnumerable<Product> GetAllCustomized()
        {
            return _db.Products.Where(u => u.CageStatus == 2).ToList();
        }
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public List<Discount> GetDiscounts()
        {
            return _db.Discounts.ToList();
        }
        //get list of product with specific tab
        public List<Product> getProductPages(int pageIndex, int pageSize)
        {
            return _db.Products.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Product> getProductShowPages(int pageIndex, int pageSize)
        {
            return _db.Products.Where(u => u.CageStatus == 1).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Product> getProductHiddenPages(int pageIndex, int pageSize)
        {
            return _db.Products.Where(u => u.CageStatus == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Product> getProductCustomizedPages(int pageIndex, int pageSize)
        {
            return _db.Products.Where(u => u.CageStatus == 2).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        //Get count of product in data
        public int getTotalProductPages()
        {
            return _db.Products.Count();
        }
        public int getTotalProductShowPages()
        {
            return _db.Products.Where(u => u.CageStatus == 1).Count();
        }
        public int getTotalProductHiddenPages()
        {
            return _db.Products.Where(u => u.CageStatus == 0).Count();
        }
        public int getTotalProductCustomizedPages()
        {
            return _db.Products.Where(u => u.CageStatus == 2).Count();
        }

        public Product GetProduct(int id)
        {
            return _db.Products.FirstOrDefault(c => c.CageId == id);
        }

        public List<Product> getListProductForUser()
        {
            return _db.Products
                        .Where(p => p.CageStatus.Equals(1))
                        .Include(p => p.Discount)
                        .ToList();
        }
        public List<Product> getProductPagesForUser(int pageIndex, int pageSize)
        {
            return this.getListProductForUser().Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
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
        /// <summary>
        /// This part will container AccessoryDAO 
        /// </summary>
        /// <returns></returns>

        UserDAO usr = new UserDAO();
        public List<Accessory> GetAccessories()
        {
            return _db.Accessories.Where(a => a.AccessoryStatus == 1).ToList();
        }
        public Accessory getDetailAccessoryByID(int accessoryID)
        {
            return _db.Accessories.FirstOrDefault(a => a.AccessoryId == accessoryID);
        }


        public List<Accessory> GetAccessoryByName(string name)
        {
            return _db.Accessories.Where(x => x.AccessoryName.Contains(name)).ToList();
        }
        public List<Accessory> getAccessoryPages(int pageIndex, int pageSize)
        {
            return _db.Accessories.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }


        public Tuple<int, int> getRatingAccessory(int accessoryID)
        {
            var countFeedback = (from p in _db.Accessories
                                 join od in _db.OrderDetails on p.AccessoryId equals od.AccessoryId
                                 join o in _db.Orders on od.OrderId equals o.OrderId
                                 join fed in _db.Feedbacks on o.OrderId equals fed.OrderId
                                 where p.AccessoryId == accessoryID
                                 select fed.FeedbackId).Count();
            var avgFeedback = (from p in _db.Accessories
                               join od in _db.OrderDetails on p.AccessoryId equals od.AccessoryId
                               join o in _db.Orders on od.OrderId equals o.OrderId
                               join fed in _db.Feedbacks on o.OrderId equals fed.OrderId
                               where p.AccessoryId == accessoryID
                               select fed.Rating).Average();
            if (countFeedback > 0)
            {
                return Tuple.Create(countFeedback, (int)avgFeedback);
            }
            else return Tuple.Create(0, 0);

        }

        /// <summary>
        /// Get count of product in data
        /// </summary>
        /// <returns></returns>
        public int getTotalAccessoryPages()
        {
            return _db.Accessories.Count();
        }






        public List<Product> comparisionProduct(int prod1, int prod2)
        {
            if (_products == null)
            {
                _products = new List<Product>();
            }

            var product1 = _db.Products.FirstOrDefault(p => p.CageId == prod1);
            var product2 = _db.Products.FirstOrDefault(p => p.CageId == prod2);

            if (product1 != null && product2 != null)
            {
                List<Product> list = new List<Product>();
                list.Add(product1);
                list.Add(product2);
                return list;
            }
            else
            {
                return new List<Product>();
            }
        }

        public int AddCustomizeCage(Product p)
        {
            if (p != null)
            {
                _db.Products.Add(p);
                int affectedRows = _db.SaveChanges();

                // If the save was successful and only one entity was affected
                if (affectedRows == 1)
                {
                    // Access the updated ProductId from the entity
                    int productId = p.CageId;

                    return productId;
                }
            }
            return 0;
        }



        public List<Product> FillterProduct(int opt)
        {
            switch (opt)
            {
                case 0:
                    return getListProductForUser(); 
                case 1:
                    var product = getListProductForUser().Where(p => p.Price > 500000 && p.Price <= 1000000);
                    return product.ToList();
                case 2:
                    product = getListProductForUser().Where(p => p.Price > 1000000 && p.Price <= 1500000);
                    return product.ToList();
                case 3:
                    product = getListProductForUser().Where(p => p.Price > 1500000 && p.Price <= 2500000);
                    return product.ToList();
                case 4:
                    product = getListProductForUser().Where(p => p.Price > 2500000 && p.Price <= 6000000);
                    return product.ToList();
                default:
                    return getListProductForUser();

            }
        }







    }
}
