using Microsoft.Win32;
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
    /// Interaction logic for UploadQR.xaml
    /// </summary>
    public partial class UploadQR : UserControl
    {
        public UploadQR()
        {
            InitializeComponent();
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a QR code that describe your desire product to add to you shopping card";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                this.imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }

        }
    }
}
