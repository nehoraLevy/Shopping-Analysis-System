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

        public static List<ShoppingCart> shoppingCarts { get; private set; }

        public ShoppingCartModel()  
        {
            if (shoppingCarts == null)
                shoppingCarts = new List<ShoppingCart>();
            _dataManagement = new BL.BLogic().DataManagement;
            Filter();
        }

        public void Filter(DateTime? startDate = null, DateTime? endDate = null)
        {
            shoppingCarts.Clear();
            _dataManagement.GetShoppingCarts(startDate, endDate).ToList().ForEach(t => shoppingCarts.Add(t));
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
