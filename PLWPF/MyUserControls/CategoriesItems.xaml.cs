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
    /// Interaction logic for CategoriesItems.xaml
    /// </summary>
    public partial class CategoriesItems : UserControl
    {
        public CategoriesItems(int indexCatergory=0)
        {
            InitializeComponent();

            CategoryVM vm = new CategoryVM();
            //MyUserControls.Item ucItem; 
            //this.itemsControl.ItemsSource = vm.CategoriesList[1].Products;

            //StackPanel sp = new StackPanel();
            for (int i = 0; i < vm.CategoriesList[indexCatergory].Products.Count; i++)
            {
                MyUserControls.Item item = new MyUserControls.Item(vm.CategoriesList[indexCatergory].Products[i]);
                item.Name = "item" + i;
                sp.Children.Add(item);
            }
        }
    }
}
