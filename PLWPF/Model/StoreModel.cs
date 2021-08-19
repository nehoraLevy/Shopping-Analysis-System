using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PLWPF.Model
{
    public class StoresModel
    {
        IDataManagement _dataManagement;
        public List<Store> StoresList { get; private set; }
        public StoresModel()
        {
            _dataManagement = new BL.BLogic().DataManagement;
            StoresList = new List<Store>(_dataManagement.GetStores());
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
