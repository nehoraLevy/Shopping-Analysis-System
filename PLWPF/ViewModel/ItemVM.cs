using BE;
using System;
using System.Collections.Generic;
using System.Text;

namespace PLWPF.ViewModel
{
    public class ItemVM
    {
        public List<Product> productList;
        BL.BLogic bl;

        public ItemVM(Category c)
        {
            bl = new BL.BLogic();

            foreach (var v in c.Products)
            {
                productList.Add(v);
            }

        }

    }
}
