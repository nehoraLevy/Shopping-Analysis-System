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
        public Item()
        {
            InitializeComponent();

            CategoryVM vm = new CategoryVM();
            List<string> productName = new List<string>();
            List<double> price = new List<double>();
            List<string> images = new List<string>();
            foreach (var v in vm.CategoriesList)
            {
                foreach( var a in v.Products)
                {
                    productName.Add(a.Name);
                    images.Add(a.ImageFileName);
                    price.Add(a.Price);
                }
                
            }
            this.productName.Text = productName[1];
            this.price.Text = price[0].ToString();
            this.image.DataContext=images[0];

        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            //this.IntegerUpDown.amount;
        }
    }
}
