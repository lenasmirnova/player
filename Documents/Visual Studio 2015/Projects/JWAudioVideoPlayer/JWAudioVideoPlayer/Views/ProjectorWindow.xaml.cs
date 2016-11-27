using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace JWAudioVideoPlayer.Views
{
    public partial class ProjectorWindowV : Window
    {
        public ProjectorWindowV()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(Window_Loaded);
        }

        public void ShowOnSecondScreen()
        {
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            
            Rectangle workingArea = Screen.AllScreens[0].WorkingArea;
            this.Left = workingArea.Left;
            this.Top = workingArea.Top;
            this.Width = workingArea.Width;
            this.Height = workingArea.Height;
            this.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Maximized;
            Visibility = Visibility.Collapsed;
            Topmost = true;
            WindowStyle = WindowStyle.None;
            ResizeMode = ResizeMode.NoResize;
            Visibility = Visibility.Visible;
        }
    }
}
