using BE;
using BL;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PLWPF.ViewModel
{
    public class ProductVM
    {
        public ProductsModel model;

        
        public ProductVM()
        {
            model = new ProductsModel();
            
        }
    }
}
