﻿using PLWPF.ViewModel;
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
    /// Interaction logic for PieChartStore.xaml
    /// </summary>
    public partial class PieChartStore : UserControl
    {
        public String Id { get; set; }
        public PieChartStore()
        {
            InitializeComponent();
            GraphPieVM vm = new GraphPieVM(Id);
            this.Pie.Series = vm.PieCollection;
        }
    }
}
