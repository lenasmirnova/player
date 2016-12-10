using System.Windows;

namespace JWAudioVideoPlayer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Program startPoint = new Program();
            DataContext = startPoint;

            Closing += startPoint.OnWindowClosing;
        }
    }
}
