using BE;
using PLWPF.ViewModel;
using Syncfusion.Windows.Forms;
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
        public ProductTransaction pt;
        //public sh
        public Item(Product product)
        {
            InitializeComponent();
            p = product;
            CategoryVM vm = new CategoryVM();
            ProductVM pvm = new ProductVM();
            List<string> productName = new List<string>();
            List<double> price = new List<double>();
            List<string> images = new List<string>();
            /*
            foreach( var a in vm.CategoriesList[0].Products)
            {
                productName.Add(a.Name);
                images.Add(a.ImageFileName);
                price.Add(a.Price);
             }*/
            if (p!=null)
            {
                this.productName.Text = p.Name;
                this.price.Text = p.Price.ToString();
                this.image.DataContext = p.ImageFileName;
            }
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            pt = new ProductTransaction();
            pt.Product = p;
            pt.Amount = this.IntegerUpDown.amount;
            pt.UnitPrice = (float)(pt.Amount * p.Price);
            pt.Amount = this.IntegerUpDown.amount;
            BE.StaticMember.sc.ProductTransactions.Add(pt);
            BE.StaticMember.totalCost += pt.UnitPrice;
            MessageBox.Show("the products add to the shopping cart succefully");

        }
    }
}

