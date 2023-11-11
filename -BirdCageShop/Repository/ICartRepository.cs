using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public  interface ICartRepository
    {
        int deleteProductfromCart(int productID, int type);
        void updateQuantity(int productID, int quantity,int type);
        int addProductToCart(int productID, int quantity, int type);
        List<CartItem> showCart();
        void clearCart();
        void showCustomizeUserCageInCart(int userID);
    }
}
