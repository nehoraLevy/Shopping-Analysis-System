using PLWPF.ViewModel;
using System;
using System.Collections.Generic;
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

namespace PLWPF.MyUserControls
{
    /// <summary>
    /// Interaction logic for PdfRecommendedListUC.xaml
    /// </summary>
    public partial class PdfRecommendedListUC : UserControl
    {
        PdfRecommendedVM vm;
        public PdfRecommendedListUC()
        {
            InitializeComponent();
            vm= new PdfRecommendedVM(); 
        }

        private void CreatePdf2Button_Click(object sender, RoutedEventArgs e)
        {
            vm.associationModel.CreateShopingListRecommendation("pdf");
            //var file = File.Load(Path.GetFullPath(@"C:\Users\levy\Desktop\ShoppingList.pdf"));
            FileStream stream = new FileStream(@"C:\Users\levy\Desktop\ShoppingList.pdf", FileMode.Open);

            MessageBox.Show("The Document is on Your Desktop");
            /*
            //Load PDF file using stream.
            this.pdfViewer.Load(stream);*/

        }

    }
}

/*
 * xmlns:syncfusion="clr-namespace:Syncfusion.Windows.PdfViewer; assembly=Syncfusion.PdfViewer.WPF"
 * <syncfusion:PdfViewerControl x:Name="pdfViewer"></syncfusion:PdfViewerControl>
 */
