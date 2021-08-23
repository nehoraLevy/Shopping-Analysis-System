using BE;
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
    /// Interaction logic for TabControlOfShop.xaml
    /// </summary>
    public partial class TabControlOfShop : UserControl
    {

        //public Product product;
        public ShoppingCardVM shoppingcVM;

        public StoreVM stores;
        MyUserControls.Item item;
        public ShoppingCart sc;
        public TabControlOfShop()
        {
            InitializeComponent();
            BE.StaticMember.totalCost = 0;
            BE.StaticMember.sc = new ShoppingCart();
            BE.StaticMember.sc.ProductTransactions = new List<ProductTransaction>();
            CategoryVM vm = new CategoryVM();
            sc = BE.StaticMember.sc;
            stores = new StoreVM();
            this.store.ItemsSource = stores.store.StoresList.Select(t => t.Name);
            shoppingcVM = new ShoppingCardVM(); 

            for (int i = 0; i < vm.cm.CategoriesList[0].Products.Count; i++)
            {
                item = new MyUserControls.Item(vm.cm.CategoriesList[0].Products[i]);
                item.Name = "item" + i;
                sp_1.Children.Add(item);
            }
            
            
            for (int i = 0; i < vm.cm.CategoriesList[1].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[1].Products[i]);
                item1.Name = "item" + i;
                sp_2.Children.Add(item1);
            }

            for (int i = 0; i < vm.cm.CategoriesList[2].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[2].Products[i]);
                item1.Name = "item" + i;
                sp_3.Children.Add(item1);
            }

            for (int i = 0; i < vm.cm.CategoriesList[3].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[3].Products[i]);
                item1.Name = "item" + i;
                sp_4.Children.Add(item1);
            }

            for (int i = 0; i < vm.cm.CategoriesList[4].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[4].Products[i]);
                item1.Name = "item" + i;
                sp_5.Children.Add(item1);
            }

            for (int i = 0; i < vm.cm.CategoriesList[5].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[5].Products[i]);
                item1.Name = "item" + i;
                sp_6.Children.Add(item1);
            }

            for (int i = 0; i < vm.cm.CategoriesList[6].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[6].Products[i]);
                item1.Name = "item" + i;
                sp_7.Children.Add(item1);
            }

            for (int i = 0; i < vm.cm.CategoriesList[7].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[7].Products[i]);
                item1.Name = "item" + i;
                sp_8.Children.Add(item1);
            }


        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ShoppingCart c = new ShoppingCart();
            c.BuyDate= this.date.SelectedDate.Value;
            string s = store.SelectedItem.ToString();
            String sortedBy = store.SelectedItem.ToString();
            c.Store = new Store();
            c.Store = stores.stores.Where(s => s.Name == sortedBy).FirstOrDefault();
            c.Id = ++shoppingcVM.sc.num;
            c.ProductTransactions = new List<ProductTransaction>();
            foreach (var v in sc.ProductTransactions)
                c.ProductTransactions.Add(v);
            c.TotalPrice = BE.StaticMember.totalCost;
            shoppingcVM.sc.Add(c);
            MessageBox.Show("The Shopping Cart added Succefully, Total Cost: " + c.TotalPrice, "Finish");

            //איתחלתי אותו לnull מאחר והגדרתי אותו לנל כדי שהבנים יוכלו לגשת אליו ולהוסיף לעגלה את המוצר שנבחר
            //לולטה על כל הפרודקטים בכל הקטגוריות ולהכניס לעגלה ואת העגלה להכניס לעגלה של ה VIEW MODEL.

        }
    }
}
