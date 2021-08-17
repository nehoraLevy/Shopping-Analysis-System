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
    /// Interaction logic for IntegerUpDownUserControl.xaml
    /// </summary>
    public partial class IntegerUpDownUserControl : UserControl
    {
        public int amount;
        public IntegerUpDownUserControl()
        {
            InitializeComponent();
            this.UpDown.Value = 0;
            this.UpDown.Minimum = 0;
            this.UpDown.Maximum = 10;
            amount = 0;
            
        }


        private void IntegerUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            amount = (int)e.NewValue;
            this.UpDown.Value = (int?)e.NewValue;


        }
    }
}
