
using BE;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLWPF.ViewModel
{
    
    public class StoreVM
    {
        public StoresModel store;
        public List<Store> stores;
        public StoreVM()
        {
            store = new StoresModel();
            stores = store.StoresList;          
        }
    }
}
