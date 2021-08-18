using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BL;
using BE;
using PLWPF.Model;
using PLWPF.ViewModel;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ShoppingCart sc;//check if he need to be static
        public CategoryVM vm;
        public StoreVM svm = new StoreVM();
        public MainWindow()
        {
            InitializeComponent();
            Window test = new test();
            test.Show();
            sc = new ShoppingCart();
            vm = new CategoryVM();
            svm = new StoreVM();

        List<Category> tabItems = new List<Category>();
            tabItems.AddRange(vm.cm.CategoriesList);
            TabControl1.ItemsSource = tabItems;
            this.stores.ItemsSource = svm.stores.Select(v => v.Name);


            //CategoryVM vm = new CategoryVM();
            //MyUserControls.Item ucItem; 
            //this.itemsControl.ItemsSource = vm.CategoriesList[1].Products;
            /*
            StackPanel sp = new StackPanel();
            for (int i = 0; i < vm.cm.CategoriesList[0].Products.Count; i++)
            {
                MyUserControls.Item item = new MyUserControls.Item(vm.cm.CategoriesList[0].Products[i]);
                item.Name = "item" + i;
                sp.Children.Add(item);
            }*/



        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sc.Store = new Store() { Name = this.stores.SelectedItem.ToString() };
        }


        private void calendar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            sc.BuyDate = (DateTime)this.date.SelectedDate;
        }

        private void TabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string name=this.TabControl1.SelectedItem.ToString();
            //MyUserControls.CategoriesItems ci = new MyUserControls.CategoriesItems(name);
            //to show the products of tha selected category
 
        }
    }
}

