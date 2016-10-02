using System.Windows.Controls;

namespace JWAudioVideoPlayer.Views
{
    /// <summary>
    /// Interaction logic for WebsiteV.xaml
    /// </summary>
    public partial class WebsiteV : UserControl
    {
        public WebsiteV()
        {
            InitializeComponent();
            jwBrowser.Navigate("http://www.jw.org");
        }
    }
}
