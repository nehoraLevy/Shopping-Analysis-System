using BE;
using PLWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PLWPF.MyUserControls
{
    /// <summary>
    /// Interaction logic for Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Product p;
       
        public Item(Product product)
        {
            InitializeComponent();
            p = product;
            CategoryVM vm = new CategoryVM();
            ProductVM pvm = new ProductVM();
            List<string> productName = new List<string>();
            List<double> price = new List<double>();
            List<string> images = new List<string>();
            this.productName.Text = p.Name;
            this.price.Text = p.Price.ToString();
            this.image.DataContext = p.ImageFileName;
            /*
            foreach (var v in vm.CategoriesList)

                foreach (var a in vm.CategoriesList[0].Products)
                {
                    foreach (var a in v.Products)
                    {
                        productName.Add(a.Name);
                        images.Add(a.ImageFileName);
                        price.Add(a.Price);
                    }

                }

            this.productName.Text = pvm.ProductsList[0].Name;
            this.price.Text = pvm.ProductsList[0].Price.ToString();
            this.image.DataContext = pvm.ProductsList[0].ImageFileName;
            

            
            productName.Add(a.Name);
            images.Add(a.ImageFileName);
            price.Add(a.Price);
            }*/


        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            ProductTransaction pt = new ProductTransaction();
            pt.Product = p;
            pt.Amount = this.IntegerUpDown.amount;
        }
    }
}

