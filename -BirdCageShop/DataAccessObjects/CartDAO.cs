using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
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
        private static List<CartItem> odList;
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
                var product = _db.Products.Include(p => p.Discount).First(p => productID == p.CageId);
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
                    od.DetailQuantity = quantity;
                    ///Check product have discout or not
                    ///
                    if (product.Discount == null || product.Discount.Discount1 == 0)
                    {
                        od.DetailPrice = (decimal)product.Price;
                    }
                    else
                    {
                        ///Price after discount successfully!
                        od.DetailPrice = (decimal)(product.Price * (1-(product.Discount.Discount1)));    
                    }
                    od.TotalPrice = od.DetailPrice * od.DetailQuantity;
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
                odList = new List<CartItem> ();
                addProductToCart(productID, quantity);
                return 1;
            }

        }
        public void updateQuantity(int productID, int quantity)
        {
            if(quantity > 0)
            {
                var product = _db.Products.First(p => p.CageId == productID);
                foreach (CartItem detail in odList)
                {
                    if (detail.Id == productID)
                    {
                        od = detail;
                        od.DetailQuantity = quantity;
                        od.TotalPrice = od.DetailPrice * od.DetailQuantity;
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

        public void clearCart()
        {
            odList.Clear();
        }

    }
}
