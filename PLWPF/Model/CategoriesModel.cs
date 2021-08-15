
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
    public class CategoriesModel
    {
        IDataManagement _dataMenegement;
        public List<Category> CategoriesList { get; private set; }
        public CategoriesModel()
        {
            _dataMenegement = new BL.BLogic().DataManagement;
            CategoriesList = new List<Category>();
            Filter();
        }

        public void Filter(string name = "")
        {
            CategoriesList.Clear();
            foreach (BE.Category item in _dataMenegement.GetCategories(name))
                CategoriesList.Add(item);
        }

        public void Update(Category category)
        {
            _dataMenegement.UpdateCategory(category);
        }

        public void AddCategory(Category category)
        {
            _dataMenegement.AddCategory(category);
        }

    }
}
