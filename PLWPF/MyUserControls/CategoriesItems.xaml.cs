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
    /// Interaction logic for CategoriesItems.xaml
    /// </summary>
    public partial class CategoriesItems : UserControl
    {
        public CategoriesItems(string indexCatergory)
        {
            InitializeComponent();

            CategoryVM vm = new CategoryVM();
            Category c= new Category(vm.CategoriesList.Find(i => i.Name == indexCatergory));
            if (c == null)
            {
                c = new Category(vm.CategoriesList[0]);
            }
            for (int i = 1; i < c.Products.Count-1; i++)
            {
                Console.WriteLine(c.Products[i].Name);
                MyUserControls.Item item = new MyUserControls.Item(c.Products[i]);
                item.Name = "item" + i;
                sp.Children.Add(item);
                

            }
            
        }
    }
}
