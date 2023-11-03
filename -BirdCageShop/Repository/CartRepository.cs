using BusinessObjects.Models;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly CartDAO _dao;
        public CartRepository()
        {
            _dao = new CartDAO();
        }
        public int addProductToCart(int productID, int quantity) => _dao.addProductToCart(productID, quantity);

        public void clearCart() => _dao.clearCart();

        public int deleteProductfromCart(int productID) => _dao.deleteProductfromCart(productID);

        public List<CartItem> showCart() => _dao.showCart();

        public void updateQuantity(int productID, int quantity) =>_dao.updateQuantity(productID, quantity);

    }
}
