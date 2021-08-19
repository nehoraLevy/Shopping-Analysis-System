using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PLWPF.Model
{
    public class ShoppingCartModel
    {
        public IDataManagement _dataManagement;

       

        public ShoppingCartModel()  
        {

            _dataManagement = new BL.BLogic().DataManagement;
            
        }



        public void Add(ShoppingCart shoppingCart)
        {
            _dataManagement.AddShoppingCart(shoppingCart);
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _dataManagement.UpdateShoppingCart(shoppingCart);
        }

    }
}
