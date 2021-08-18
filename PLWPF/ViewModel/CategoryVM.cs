using BE;
using BL;
using PLWPF.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PLWPF.ViewModel
{
    public class CategoryVM
    {
        
        public CategoriesModel cm;
        public CategoryVM()
        {
            cm = new CategoriesModel();
        }
    }
}
