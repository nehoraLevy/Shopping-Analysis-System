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
    /// Interaction logic for TabControlOfShop.xaml
    /// </summary>
    public partial class TabControlOfShop : UserControl
    {
        public TabControlOfShop()
        {
            InitializeComponent();
            CategoryVM vm = new CategoryVM();

            for (int i = 0; i < vm.cm.CategoriesList[0].Products.Count; i++)
            {
                MyUserControls.Item item = new MyUserControls.Item(vm.cm.CategoriesList[0].Products[i]);
                item.Name = "item" + i;
                sp_1.Children.Add(item);
            }

            for (int i = 0; i < vm.cm.CategoriesList[1].Products.Count; i++)
            {
                MyUserControls.Item item1 = new MyUserControls.Item(vm.cm.CategoriesList[1].Products[i]);
                item1.Name = "item" + i;
                sp_2.Children.Add(item1);
            }


        }
    }
}
