using LiveCharts;
using LiveCharts.Wpf;
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
    /// Interaction logic for PieChartUserControl.xaml
    /// </summary>
    /// 
    //LabelPoint="{Binding PointLabel}"
    //DataClick="Chart_OnDataClick"
   
    public partial class PieChartUserControl : UserControl
    {
        GraphPieVM vm;
        public String Id { get; set; }
        public PieChartUserControl()
        {
            InitializeComponent();
            vm = new GraphPieVM(Id);
            this.DataContext = vm;
            this.Pie.Series = vm.PieCollection;
        }
        public void initProperty(String id)
        {
            Id = id;

        }

        private void Button_Click_Apply(object sender, RoutedEventArgs e)
        {
            string[] _filter = filterProduct.SelectedItem.ToString().Split(' ');
            String filter1 = _filter[1];
            string sortedBy = filterProduct.SelectedItem.ToString();
            string dateBy = filterTime.SelectedItem.ToString();
            if (filter1 == "Store")
                vm.filterPiebyStores(dateBy);
            if (filter1 == "Category")
                vm.filterPiebyCategories(dateBy);
            this.Pie.Series = vm.PieCollection;
        }
    }
}


/*
 *             <lvc:PieChart.Series>
                <lvc:PieSeries x:Name="p_1" Title="Milk Products" Values="5" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_2" Title="Fruits and Vegetable" Values="8" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_3" Title="Fish and Meat" Values="7" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_4" Title="Canned food" Values="4" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_5" Title="Cooking and Baking" Values="2" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_6" Title="Legumes and sweets " Values="9" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_7" Title="Drinks" Values="4" DataLabels="True"/>
                <lvc:PieSeries x:Name="p_8" Title="Home maintenance and Toiletries " Values="6" DataLabels="True"/>
            </lvc:PieChart.Series>
*/
