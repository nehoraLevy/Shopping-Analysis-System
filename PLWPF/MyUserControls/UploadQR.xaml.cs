using BE;
using BL;
using Microsoft.Win32;
using PLWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for UploadQR.xaml
    /// </summary>
    public partial class UploadQR : UserControl
    {
        public ShoppingCart sc;
        public Product product;
        public ShoppingCardVM shoppingcVM;
        
        public StoreVM stores;
        public UploadQR()
        {
            InitializeComponent();
            stores = new StoreVM();
            this.store.ItemsSource = stores.store.StoresList.Select(t => t.Name); ;
            shoppingcVM = new ShoppingCardVM();
            sc = new ShoppingCart();
            sc.ProductTransactions = new List<ProductTransaction>();
            product = new Product();
            MyUserControls.IntegerUpDownUserControl uc = new IntegerUpDownUserControl();

            uc.Visibility = (Visibility)1;

        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            ProductVM pvm = new ProductVM();
            List<Product> products = pvm.model.ProductsList;
            uc.Visibility = (Visibility)0;
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a QR code that describe your desire product to add to you shopping card";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                string path = op.FileName;
                product= products.Find(i => i.Name == DataManagement.qrDecode(path));
                if (product != null)
                {
                    this.imgPhoto_Copy.Source = new BitmapImage(new Uri(products.Find(i => i.Name == product.Name).ImageFileName));
                    this.qrPhoto_Copy.Source = new BitmapImage(new Uri(path));
                    this.imgPhoto.Source = new BitmapImage(new Uri(products.Find(i => i.Name == product.Name).ImageFileName));
                    this.ProductName.Text = product.Name;
                    this.ProductPrice.Text = "Unit price: "+product.Price.ToString() + "$";
                }
                
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            ProductTransaction pt = new ProductTransaction();
            int amount = this.uc.amount;
            pt.Amount = amount;
            pt.Product = product;
            sc.BuyDate = this.date.SelectedDate.Value;
            string s=store.SelectedItem.ToString();
            string[] _time = s.Split(' ');
            String sortedBy = _time[1];

            sc.Store = stores.stores.Where(s => s.Name == sortedBy).FirstOrDefault();
            sc.ProductTransactions.Add(pt);
            pt.shoppingCart = sc;
            sc.ProductTransactions.Add(pt);
            sc.Id = shoppingcVM.sc.num;
            MessageBox.Show("the products add to the shopping cart succefully");
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            double price = 0;
            foreach (var i in sc.ProductTransactions)
                price += i.Amount * i.UnitPrice;
            sc.TotalPrice = price;
            shoppingcVM.sc.Add(sc);
            MessageBox.Show("the shopping cart added succefully");
        }
    }
}
