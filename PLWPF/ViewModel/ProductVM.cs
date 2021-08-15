using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLWPF.ViewModel
{
    public class ProductVM
    {

        DataManagement dm = new DataManagement();
        public List<Product> ProductsList;
        public ProductVM()
        {
            ProductsList = dm.GetProducts().ToList();
        }
    }
}
