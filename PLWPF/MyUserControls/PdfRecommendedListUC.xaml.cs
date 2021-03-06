using GemBox.Document;
using Microsoft.Win32;
using PLWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
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
using System.Windows.Xps.Packaging;
using SaveOptions = GemBox.Document.SaveOptions;

namespace PLWPF.MyUserControls
{
    /// <summary>
    /// Interaction logic for PdfRecommendedListUC.xaml
    /// </summary>
    public partial class PdfRecommendedListUC : UserControl
    {
        PdfRecommendedVM vm;
        XpsDocument xpsDocument;
        public PdfRecommendedListUC()
        {
            InitializeComponent();
            vm= new PdfRecommendedVM(); 
        }

        private void CreatePdf2Button_Click(object sender, RoutedEventArgs e)
        {
            string[] str= vm.associationModel.CreateShopingListRecommendation("pdf");
            //var file = File.Load(Path.GetFullPath(@"C:\Users\levy\Desktop\ShoppingList.pdf"));
            FileStream stream = new FileStream(@"C:\Users\levy\Desktop\ShoppingList.pdf", FileMode.Open);

            MessageBox.Show("The Document is on Your Desktop");
            foreach (var i in str)
            {
                string[] s = i.Split(",");
                //this.dataGrid.CanUserAddRows["col_1"] = s[0];
            }
        }

    }
}

