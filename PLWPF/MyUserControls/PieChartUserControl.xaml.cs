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
    public partial class PieChartUserControl : UserControl
    {
        public String Id { get; set; }
        public PieChartUserControl()
        {
            InitializeComponent();
        }
        public void initProperty(String id)
        {
            Id = id;
            GraphPieVM vm = new GraphPieVM(Id);
            this.DataContext = vm;
        }
    }
}
