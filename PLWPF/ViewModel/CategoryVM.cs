using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace PLWPF.ViewModel
{
    public class CategoryVM
    {
        IDataManagement dm = new DataManagement();
        public List<Category> CategoriesList;
        public CategoryVM()
        {
            CategoriesList = dm.GetCategories().ToList();
            //List<String> a = Categories.Select(t => t.Name).ToList();
        }
    }
}
