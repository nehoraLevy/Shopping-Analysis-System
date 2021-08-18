using BE;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLWPF.ViewModel
{
    class ShoppingCardVM
    {
        ShoppingCartModel sc ;
        ShoppingCart shoppingCart;
        ShoppingCardVM()
        {
            sc = new ShoppingCartModel();
            shoppingCart = new ShoppingCart();

        }

    }
}
