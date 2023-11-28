using BusinessObjects.Models;

namespace DataAccessObjects
{
    public class AccessoryDAO
    {
        private readonly CageShopUni_alaContext _db;

        public AccessoryDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public Accessory GetAccessoryById(int id)
        {
            return _db.Accessories.FirstOrDefault(p => p.AccessoryId == id);
        }

        public List<Accessory> GetAccessoryByName(string name)
        {
            return _db.Accessories.Where(p => p.AccessoryName.Contains(name)).ToList();
        }

        public void Add(Accessory accessory)
        {
            _db.Add(accessory);
            _db.SaveChanges();
        }

        public void Update(Accessory accessory)
        {
            var acc = GetAccessoryById(accessory.AccessoryId);
            if (acc != null)
            {
                acc.AccessoryName = accessory.AccessoryName;
                acc.AccessoryPrice = accessory.AccessoryPrice;
                acc.AccessoryDescription = accessory.AccessoryDescription;
                acc.AccessoryQuantity = accessory.AccessoryQuantity;
                acc.AccessoryStatus = accessory.AccessoryStatus;
                acc.AccessoryImg = accessory.AccessoryImg;
                acc.CategoryId = accessory.CategoryId;
                acc.DiscountId = accessory.DiscountId;

                _db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var acc = GetAccessoryById(id);
            var od = _db.OrderDetails.FirstOrDefault(od => od.CageId == id);
            if (acc != null && od == null)
            {
                _db.Accessories.Remove(acc);
                _db.SaveChanges();
            }
            else if (acc != null)
            {
                acc.AccessoryStatus = 0;
                _db.SaveChanges();
            }
        }

        public IEnumerable<Accessory> GetAll()
        {
            return _db.Accessories.ToList();
        }
        public IEnumerable<Accessory> GetAllShow()
        {
            return _db.Accessories.Where(u => u.AccessoryStatus == 1).ToList();
        }
        public IEnumerable<Accessory> GetAllHidden()
        {
            return _db.Accessories.Where(u => u.AccessoryStatus == 0).ToList();
        }
        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }
        public List<Discount> GetDiscounts()
        {
            return _db.Discounts.ToList();
        }
        public List<Accessory> getAccessoryPages(int pageIndex, int pageSize)
        {
            return _db.Accessories.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Accessory> getAccessoryShowPages(int pageIndex, int pageSize)
        {
            return _db.Accessories.Where(u => u.AccessoryStatus == 1).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public List<Accessory> getAccessoryHiddenPages(int pageIndex, int pageSize)
        {
            return _db.Accessories.Where(u => u.AccessoryStatus == 0).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
        }
        public int getTotalAccessoryPages()
        {
            return _db.Accessories.Count();
        }
        public int getTotalAccessoryShowPages()
        {
            return _db.Accessories.Where(u => u.AccessoryStatus == 1).Count();
        }
        public int getTotalAccessoryHiddenPages()
        {
            return _db.Accessories.Where(u => u.AccessoryStatus == 0).Count();
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
        public List<Accessory> GetListAccessory()
        {
            return _db.Accessories.Where(p => p.AccessoryStatus == 1).ToList();
        }

        public List<Accessory> FillterProduct(int opt)
        {
            switch (opt)
            {
                case 0:
                    return GetListAccessory();
                case 1:
                    var product = GetListAccessory().Where(p => p.AccessoryPrice > 10000 && p.AccessoryPrice <= 100000);
                    return product.ToList();
                case 2:
                    product = GetListAccessory().Where(p => p.AccessoryPrice > 100000 && p.AccessoryPrice <= 150000);
                    return product.ToList();
                case 3:
                    product = GetListAccessory().Where(p => p.AccessoryPrice > 150000 && p.AccessoryPrice <= 250000);
                    return product.ToList();
                case 4:
                    product = GetListAccessory().Where(p => p.AccessoryPrice > 250000 && p.AccessoryPrice <= 500000);
                    return product.ToList();
                default:
                    return GetListAccessory();

            }
        }

    }
}

