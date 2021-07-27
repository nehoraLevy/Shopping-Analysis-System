using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace BE
{
    public class QRcode_data: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;
        //name,id,barcode,price,amount
        private int _id;
        public int Id { get => _id; set => SetProperty(ref _id, value); }

        private double _price;
        public double Price { get => _price; set => SetProperty(ref _price, value); }

        private string _barCode;
        public string BarCode { get => _barCode; set => SetProperty(ref _barCode, value); }


        private Store _storename;
        public Store StoreName { get => _storename; set => SetProperty(ref _storename, value); }

        private int _amount;
        public int Amount { get => _amount; set => SetProperty(ref _amount, value); }

        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        public QRcode_data()
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
