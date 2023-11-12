using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
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
            if (odList == null)
            {
                return odList = new List<CartItem>();
            }
            return odList;
        }

        public void showCustomizeUserCageInCart(int userID)
        {
            var listProduct = _db.Products.Where(p => p.CageName.Contains(userID.ToString()) && p.CageStatus == 2).ToList();

            if (listProduct.Count > 0)
            {
                if (odList == null)
                {
                    odList = new List<CartItem>();
                }

                foreach (var item in listProduct)
                {
                    // Check if an item with the same CageId already exists in odList
                    var existingCartItem = odList.FirstOrDefault(cartItem => cartItem.Id == item.CageId);

                    if (existingCartItem == null)
                    {
                        // If it doesn't exist, add the product to the cart
                        addProductToCart(item.CageId, (int)item.Quantity, 0);
                    }
                    //else
                    //{
                    //    // If it exists, you can update the quantity or take other actions
                    //    // For example, updating the quantity here, you may need to adjust this based on your CartItem class
                    //    existingCartItem.DetailQuantity += (int)item.Quantity;
                    //}
                }
            }
            else
            {
                if(odList == null)
                {
                    odList = new List<CartItem>();
                }
                
            }
        }


        public int addProductToCart(int productID, int quantity, int type)
        {
            if (odList != null)
            {
                int countList = odList.Count;
                if (type == 0)
                {
                    var product = _db.Products.Include(p => p.Discount).First(p => productID == p.CageId);
                    if (product != null)
                    {
                        int productStatus = (int)product.CageStatus;
                        ///Check if product already in cart => increase quantity
                        foreach (var item in odList)
                        {
                            if (item.Id == productID && productStatus != 2 && item.type == type)
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
                            od.DetailPrice = (decimal)(product.Price * (1 - (product.Discount.Discount1)));
                        }
                        od.TotalPrice = od.DetailPrice * od.DetailQuantity;
                        od.type = type; /// 0 is Cage 
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
                    var ac = _db.Accessories.Include(a => a.Discount).First(a => productID == a.AccessoryId);
                    if (ac != null)
                    {
                        ///Check if product already in cart => increase quantity
                        foreach (var item in odList)
                        {
                            if (item.Id == productID && item.type == type)
                            {
                                item.DetailQuantity++;
                                return 1;
                            }
                        }
                        ///If not it will create  a new object
                        od = new CartItem();
                        od.Id = ac.AccessoryId;
                        od.CageName = ac.AccessoryName;
                        od.DetailQuantity = quantity;
                        ///Check product have discout or not
                        ///
                        if (ac.Discount == null || ac.Discount.Discount1 == 0)
                        {
                            od.DetailPrice = (decimal)ac.AccessoryPrice;
                        }
                        else
                        {
                            ///Price after discount successfully!
                            od.DetailPrice = (decimal)((decimal)ac.AccessoryPrice * (1 - ac.Discount.Discount1));
                        }
                        od.TotalPrice = od.DetailPrice * od.DetailQuantity;
                        od.type = type; /// 1 is Accessory 
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


            }
            else
            {
                odList = new List<CartItem>();
                addProductToCart(productID, quantity, type);
                return 1;
            }

        }
        public void updateQuantity(int productID, int quantity, int type)
        {
            if (type == 0)
            {
                if (quantity > 0)
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
            else
            {
                if (quantity > 0)
                {
                    var product = _db.Accessories.First(p => p.AccessoryId == productID);
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

        }
        public int deleteProductfromCart(int productID, int type)
        {
            int countList = odList.Count();
            var product = _db.Products.First(p => p.CageId == productID);
            foreach (var item in odList)
            {
                if (item.Id == productID && item.type == type)
                {

                    od = item;
                    odList.Remove(od);
                    if (product.CageStatus == 2) _db.Products.Remove(product); _db.SaveChanges();   
                    

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
