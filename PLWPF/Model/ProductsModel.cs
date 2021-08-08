using BE;
using BL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PL.Model
{
    public class ProductsModel
    {
        IDataManagement _dataManagement;
        public ObservableCollection<Product> ProductsList { get; set; }
        public ProductsModel()
        {
            _dataManagement = new BL.BLogic().DataManagement;
            ProductsList = new ObservableCollection<Product>();
            Filter();
        }

        public void AddProduct(Product product)
        {
            _dataManagement.AddProduct(product);
        }

        public void Update(Product product)
        {
            _dataManagement.UpdateProduct(product);
        }

        public void Filter(string name = "", params Category[] categories)
        {
            ProductsList.Clear();
            foreach (Product i in _dataManagement.GetProducts(name))
                foreach (Category j in _dataManagement.GetCategories())
                    if (i.Category == j)
                        ProductsList.Add(i);
        }
    }
}
