using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
namespace BE
{

    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;


        private int? _id;
        public int? Id { get => _id; set => SetProperty(ref _id, value); }

        private string _password;
        public string Password { get => _password; set => SetProperty(ref _password, value); }

        private string _emailAddress;
        public string EmailAddress { get => _emailAddress; set => SetProperty(ref _emailAddress , value); }

        private string _address;
        public string Address { get => _address; set => SetProperty(ref _address, value); }

        private int _zipCode;
        public int ZipCode { get => _zipCode; set => SetProperty(ref _zipCode, value); }


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
