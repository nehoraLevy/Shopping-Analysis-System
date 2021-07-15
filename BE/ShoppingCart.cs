using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BE
{
    public class ShoppingCart: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;

        private int? _id;
        public int? Id { get => _id; set => SetProperty(ref _id, value); }

        private DateTime _buydate;
        public DateTime BuyDate { get => _buydate; set => SetProperty(ref _buydate, value); }
        
        private double _totalprice;
        public double TotalPrice { get => _totalprice; set => SetProperty(ref _totalprice, value); }

        private Store _store;
        public Store Store { get => _store; set => SetProperty(ref _store, value); }

        private ICollection<ProductTransaction> _products;
        public virtual ICollection<ProductTransaction> Products { get => _products; set => SetProperty(ref _products, value); }

        public ShoppingCart()
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
