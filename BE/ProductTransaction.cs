using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text;

namespace BE
{
    public class ProductTransaction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;

        private int _id;
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        private float _unitPrice;
        public float UnitPrice { get => _unitPrice; set => SetProperty(ref _unitPrice, value); }

        private float _amount;
        /// <summary>
        ///Amount of products.
        /// </summary>
        public float Amount { get => _amount; set => SetProperty(ref _amount, value); }

        private Product _product;
        public virtual Product Product { get => _product; set => SetProperty(ref _product, value); }

        private ShoppingCart _shoppingCart;
        public virtual ShoppingCart shoppingCart { get => _shoppingCart; set => SetProperty(ref _shoppingCart, value); }

        private Store _store;
        public virtual Store Store { get => _store; set => SetProperty(ref _store, value); }

        public ProductTransaction()
        {
            _notifyPropertyChanged = new NotifyPropertyChanged(this, (property) => OnPropertyChanged(property));
        }

        private void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            _notifyPropertyChanged.SetProperty(ref property, value, propertyName);
        }

        private void OnPropertyChanged(PropertyChangedEventArgs property)
        {
            PropertyChanged?.Invoke(this, property);
        }
    }
}
