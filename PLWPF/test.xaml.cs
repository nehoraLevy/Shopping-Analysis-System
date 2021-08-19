using PLWPF.MyUserControls;
using PLWPF.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace PLWPF
{
    public partial class test : Window
    {
        public test(ShoppingCardVM svm)
        {
            InitializeComponent();
            UploadQR qr = new UploadQR();
        }
    }
}
