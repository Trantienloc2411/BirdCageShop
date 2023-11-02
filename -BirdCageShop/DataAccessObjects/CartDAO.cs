using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class CartDAO
    {
        /// <summary>
        /// Contain product in cart;
        /// </summary>
        private static List<CartItem> odList = new List<CartItem>();
        private CartItem od;
        private CageShopUni_alaContext _db;
        public CartDAO()
        {
            _db = new CageShopUni_alaContext();
        }

        public List<CartItem> showCart()
        {
            if(odList == null)
            {
               return odList = new List<CartItem>();
            }
            return odList;
        }
        public int addProductToCart(int productID, int quantity)
        {
            if(odList != null)
            {
                int countList = odList.Count;
                var product = _db.Products.First(p => productID == p.CageId);
                if (product != null)
                {
                    ///Check if product already in cart => increase quantity
                    foreach(var item in odList)
                    {
                        if(item.Id == productID)
                        {
                            item.DetailQuantity++;
                            return 1;
                        }
                    }
                    ///If not it will create  a new object
                    od = new CartItem();
                    od.Id = product.CageId;
                    od.CageName = product.CageName;
                    od.DetailPrice = (decimal)product.Price;
                    od.DetailQuantity = quantity;
                    odList.Add(od);
                    if (odList.Count > countList)
                    {
                        return 1;
                    }
                    return 0;

                }
                else
                {
                    return 0;
                }

            }
            else
            {
                return 0;
            }

        }
        public void updateQuantity(int productID, int quantity)
        {
            if(quantity > 0)
            {
                foreach (CartItem detail in odList)
                {
                    if (detail.Id == productID)
                    {
                        od = detail;
                        od.DetailQuantity = quantity;
                        return;
                    }
                }
            }
        }
        public int deleteProductfromCart(int productID)
        {
            int countList = odList.Count();
            foreach (var item in odList)
            {
                if(item.Id == productID)
                {
                    od = item;
                    odList.Remove(od);
                    return 1;
                }
            }
            return 0;
        }
        
    }
}
