using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace BE
{
    public abstract class BasicGraph : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private NotifyPropertyChanged _notifyPropertyChanged;

        private int _id;
        public int Id { get => _id; set => SetProperty(ref _id, value); }


        private string _title;
        [MaxLength(100)]
        public string Title { get => _title; set => SetProperty(ref _title, value); }

        private string _description;
        public string Description { get => _description; set => SetProperty(ref _description, value); }


        private DateTime _startDate;
        public DateTime StartDate { get => _startDate; set => SetProperty(ref _startDate, value); }

        private DateTime _endDate;
        public DateTime EndDate { get => _endDate; set => SetProperty(ref _endDate, value); }

        private int _pastTimeAmount;
        public int PastTimeAmount { get => _pastTimeAmount; set => SetProperty(ref _pastTimeAmount, value); }

        private TimeType _timeType;
        public TimeType TimeType { get => _timeType; set => SetProperty(ref _timeType, value); }

        private GraphType _graphType;
        public GraphType GraphType { get => _graphType; set => SetProperty(ref _graphType, value); }

        private AmountOrCost _amountOrCost;
        public AmountOrCost AmountOrCost { get => _amountOrCost; set => SetProperty(ref _amountOrCost, value); }

        public BasicGraph()
        {
            _notifyPropertyChanged = new NotifyPropertyChanged(this, (property) => OnPropertyChanged(property));
        }

        protected void SetProperty<T>(ref T property, T value, [CallerMemberName] string propertyName = "")
        {
            _notifyPropertyChanged.SetProperty(ref property, value, propertyName);
        }

        private void OnPropertyChanged(PropertyChangedEventArgs property)
        {
            PropertyChanged?.Invoke(this, property);
        }
    }
}
