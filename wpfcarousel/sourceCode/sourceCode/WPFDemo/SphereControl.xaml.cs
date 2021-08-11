using System.Windows.Media;

namespace WPFDemo
{
	public partial class SphereControl
	{
		public SphereControl()
		{
			this.InitializeComponent();
		}

        public Color InnerColorBrush
        {
            get { return InnerColor.Color; }
            set { InnerColor.Color = value; }
        }
        public Color OuterColorBrush
        {
            get { return OuterColor.Color; }
            set { OuterColor.Color = value; }
        }
        public Brush SphereFill
        {
            get { return Ellipse.Fill; }
        }
	}
}