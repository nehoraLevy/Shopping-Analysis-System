
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Category: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;

        private int? _id;
        public int? Id { get => _id; set => SetProperty(ref _id, value); }

        private string _name;
        public string Name { get => _name; set => SetProperty(ref _name, value); }

        private string _imageFileName;
        public string ImageFileName { get => _imageFileName; set => SetProperty(ref _imageFileName, value); }

        private List<Product> _products;
        public virtual List<Product> Products { get => _products; set => SetProperty(ref _products, value); }

        public Category(Category category)
        {
            _notifyPropertyChanged = new NotifyPropertyChanged(this, (property) => OnPropertyChanged(property));
        }
        public Category()
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

