﻿using BusinessObjects.Models;

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
        public List<Product> getListProductForUser()
        {
            return _db.Products.Where(p => p.CageStatus.Equals(1)).ToList();
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
    }
}
