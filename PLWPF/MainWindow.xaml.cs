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
        public MainWindow()
        {
            InitializeComponent();
            CategoryVM vm = new CategoryVM();
            List<Category> tabItems = new List<Category>();
            tabItems.AddRange(vm.CategoriesList);
            TabControl1.ItemsSource = tabItems;

            Window test = new test();
            test.Show();



        }


    }
}

