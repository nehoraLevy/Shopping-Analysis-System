using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace BE
{


    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;

        private int? _id;
        public int? Id { get => _id; set => SetProperty(ref _id, value); }

        private double _price;
        public double Price { get => _price; set => SetProperty(ref _price, value); }

        private string _barCode;
        public string BarCode { get => _barCode; set => SetProperty(ref _barCode, value); }


        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _description;
        public string Description { get => _description; set => SetProperty(ref _description, value); }


        private string _imageFileName;
        public string ImageFileName { get => _imageFileName; set => SetProperty(ref _imageFileName, value); }

        private Category _category;
        public virtual Category Category { get => _category; set => SetProperty(ref _category, value); }

        public Product()
        {
            _notifyPropertyChanged = new NotifyPropertyChanged(this, (property) => OnPropertyChanged(property));
        }

        private void SetProperty<T>(ref T property, T value, [CallerMemberName]  string propertyName = "")
        {
            _notifyPropertyChanged.SetProperty(ref property, value, propertyName);
        }

        private void OnPropertyChanged(PropertyChangedEventArgs property)
        {
            PropertyChanged?.Invoke(this, property);
        }
    }
}
