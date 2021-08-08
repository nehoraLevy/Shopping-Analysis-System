using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HomeEconomicSystem.PL.Model
{
    public class StoresModel
    {
        IDataManagement _dataManagement;
        public ObservableCollection<Store> StoresList { get; private set; }
        public StoresModel()
        {
            _dataManagement = new BL.BLogic().DataManagement;
            StoresList = new ObservableCollection<Store>();
            Filter();
        }

        void Filter(string name = "")
        {
            StoresList.Clear();
            foreach (Store s in _dataManagement.GetStores(name))
                StoresList.Add(s);
        }
    }
}
