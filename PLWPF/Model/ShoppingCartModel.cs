using BE;
using BL;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PLWPF.Model
{
    public class TransactionsModel
    {
        IDataManagement _dataManagement;

        public ObservableCollection<ShoppingCart> shoppingCarts { get; private set; }

        public TransactionsModel()
        {
            _dataManagement = new BL.BLogic().DataManagement;
            shoppingCarts = new ObservableCollection<ShoppingCart>();
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
