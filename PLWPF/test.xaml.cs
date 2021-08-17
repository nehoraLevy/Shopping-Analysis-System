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
using System.Windows.Shapes;

namespace PLWPF
{
    /// <summary>
    /// Interaction logic for test.xaml
    /// </summary>
    public partial class test : Window
    {
        public test()
        {
            InitializeComponent();
            
            CategoryVM vm = new CategoryVM();
            //MyUserControls.Item ucItem; 
            //this.itemsControl.ItemsSource = vm.CategoriesList[1].Products;
            
            //StackPanel sp = new StackPanel();
            for (int i=0; i<vm.CategoriesList[0].Products.Count; i++)
            {
                MyUserControls.Item item = new MyUserControls.Item(vm.CategoriesList[0].Products[i]);
                item.Name = "item" + i;
                sp.Children.Add(item);
            }
        }
    }
}
