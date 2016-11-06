using System.Drawing;
using System.Windows;
using System.Windows.Forms;

namespace JWAudioVideoPlayer.Views
{
    /// <summary>
    /// Interaction logic for ProjectorWindow.xaml
    /// </summary>
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
            this.Visibility = Visibility.Collapsed;
            this.Topmost = true;
            this.WindowStyle = WindowStyle.None;
            this.ResizeMode = ResizeMode.NoResize;
            // re-show the window after changing style
            this.Visibility = Visibility.Visible;
        }
    }
}
