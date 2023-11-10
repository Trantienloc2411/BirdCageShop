using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Security.Cryptography.X509Certificates;

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



        /// <summary>
        /// This part is for add to cart function
        /// </summary>
        /// <param name="userID">get UserID </param>
        /// <param name="AccessoryID">Get Product ID</param>
        /// <param name="quantity">Default is 1</param>
        /// <returns>integer 1  | 0    ---  Success or not</returns>
        /// <exception cref="Exception"></exception>
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


        //public List<Product> customizeCage(Product p)
        //{

        //}

       


    }
}
