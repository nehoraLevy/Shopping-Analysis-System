using BE;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLWPF.ViewModel
{
    public class ItemVM
    {
        ProductsModel pm;

        public ItemVM(Category c)
        {
            pm = new ProductsModel();

            foreach (var v in c.Products)
            {
                pm.ProductsList.Add(v);
            }

        }

    }
}
