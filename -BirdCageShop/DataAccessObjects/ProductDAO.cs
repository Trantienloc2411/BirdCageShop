using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;

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
            return _db.Products.ToList();
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
        //Get count of product in data
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

        /// <summary>
        /// This function will be optimization to use list 
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="accessoryID"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /*
        public int AddProductToCart(int userID, int accessoryID, int quantity)
        {
            try
            {
                //Checking the cart is existed or not
                var order = _db.Orders.FirstOrDefault(o => o.UserId == userID && o.OrderStatus == "Cart");
                //if not, i will create a new cart
                if (order == null)
                {
                    try
                    {
                        //Setting some temp information i get from user
                        Order o = new Order();
                        o.UserId = userID;
                        o.OrderStatus = "Cart";
                        o.OrderDate = DateTime.Now;
                        o.OrderName = usr.GetUserById(userID).UserName;
                        _db.Add(o);
                        _db.SaveChanges();
                        //Now i use recursion to go back 
                        AddProductToCart(userID, productID, quantity);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                //in case thhe cart existed
                else
                {
                    // find the product information
                    var product = _dbContext.Products.First(p => p.CageId == productID);
                    //get information about the cart
                    var orderDetail = _dbContext.OrderDetails.FirstOrDefault(od => od.CageId == productID && od.OrderId == order.OrderId);
                    //take the price not include discount
                    if (orderDetail != null)
                    {
                        int bdb = (int)orderDetail.DetailQuantity;
                        orderDetail.DetailQuantity += 1;
                        var productCartList = this.getListcartByUserID(userID).ToList();
                        order.OrderPrice = productCartList.Sum(p => p.DetailPrice);
                        return _dbContext.SaveChanges();
                    }
                    else
                    {
                        // You need to initialize orderDetail before you can use it
                        OrderDetail od = new OrderDetail();
                        od.OrderId = order.OrderId;
                        od.CageId = productID;
                        od.DetailPrice = product.Price;
                        quantity = 1;
                        od.DetailQuantity = quantity;
                        _dbContext.OrderDetails.Add(od);
                        var productCartList = this.getListcartByUserID(userID).ToList();
                        order.OrderPrice = productCartList.Sum(p => p.DetailPrice);
                        return _dbContext.SaveChanges();
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        */
        public List<Accessory> GetAccessoryByName(string name)
        {
            return _db.Accessories.Where(x => x.AccessoryName.Contains(name)).ToList();
        }
        public List<Accessory> getAccessoryPages(int pageIndex, int pageSize)
        {
            return _db.Accessories.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        //Get count of product in data
        public int getTotalAccessoryPages()
        {
            return _db.Accessories.Count();
        }
        public int AddProductToCart(int userID, int AccessoryID, int quantity)
        {
            try
            {
                //Checking the cart is existed or not
                var order = _db.Orders.FirstOrDefault(o => o.UserId == userID && o.OrderStatus == "Cart");
                //if not, i will create a new cart
                if (order == null)
                {
                    try
                    {
                        //Setting some temp information i get from user
                        Order o = new Order();
                        o.UserId = userID;
                        o.OrderStatus = "Cart";
                        o.OrderDate = DateTime.Now;
                        o.OrderName = usr.GetUserById(userID).UserName;
                        _db.Add(o);
                        _db.SaveChanges();
                        //Now i use recursion to go back 
                        AddProductToCart(userID, AccessoryID, quantity);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                //in case thhe cart existed
                else
                {
                    // find the product information
                    var accessory = _db.Accessories.First(p => p.AccessoryId == AccessoryID);
                    //get information about the cart
                    var orderDetail = _db.OrderDetails.FirstOrDefault(od => od.AccessoryId == AccessoryID && od.OrderId == order.OrderId);
                    //take the price not include discount
                    if (orderDetail != null)
                    {
                        int bdb = (int)orderDetail.DetailQuantity;
                        orderDetail.DetailQuantity += 1;
                        var productCartList = usr.getListcartByUserID(userID).ToList();
                        order.OrderPrice = productCartList.Sum(p => p.DetailPrice);
                        return _db.SaveChanges();
                    }
                    else
                    {
                        // You need to initialize orderDetail before you can use it
                        OrderDetail od = new OrderDetail();
                        od.OrderId = order.OrderId;
                        od.AccessoryId = AccessoryID;
                        od.DetailPrice = (decimal?)accessory.AccessoryPrice;
                        quantity = 1;
                        od.DetailQuantity = quantity;
                        _db.OrderDetails.Add(od);
                        var productCartList = usr.getListcartByUserID(userID).ToList();
                        order.OrderPrice = productCartList.Sum(p => p.DetailPrice);
                        return _db.SaveChanges();
                    }
                }
                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
