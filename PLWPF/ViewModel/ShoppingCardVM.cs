using BE;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLWPF.ViewModel
{
    public class ShoppingCardVM
    {
        public ShoppingCartModel sc ;
        public ShoppingCart shoppingCart;
        public ShoppingCardVM()
        {
            sc = new ShoppingCartModel();
            shoppingCart = new ShoppingCart();
            shoppingCart.Id = ++BE.StaticMember.num;
        }

    }
}
