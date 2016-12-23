using JWAudioVideoPlayer.ViewModels;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Threading;

namespace JWAudioVideoPlayer.Views
{
    /// <summary>
    /// Interaction logic for MusicPlayerV.xaml
    /// </summary>
    public partial class MusicPlayerV : UserControl
    {
        public MusicPlayerV()
        {
            InitializeComponent();
            
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if ((mePlayer.Source != null) && (mePlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider1))
            {
                sliProgress1.Minimum = 0;
                sliProgress1.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress1.Value = mePlayer.Position.TotalSeconds;
            }
        }

        private bool mediaPlayerIsPlaying1 = false;
        private bool userIsDraggingSlider1 = false;

        private void Open_Executed(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                mePlayer.Source = new Uri(openFileDialog.FileName);
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (mePlayer != null) && (mePlayer.Source != null);
        }

        private void Play_Executed(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as MusicPlayerVm;
            mePlayer.Volume = 100;
            mePlayer.Play();
            mediaPlayerIsPlaying1 = true;
        }

        //private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = mediaPlayerIsPlaying;
        //}

        private void Pause_Executed(object sender, RoutedEventArgs e)
        {
            mePlayer.Pause();
        }

        //private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        //{
        //    e.CanExecute = mediaPlayerIsPlaying;
        //}

        private void Stop_Executed(object sender, RoutedEventArgs e)
        {
            mePlayer.Stop();
            mediaPlayerIsPlaying1 = false;
        }

        private void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider1 = true;
        }

        private void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider1 = false;
            mePlayer.Position = TimeSpan.FromSeconds(sliProgress1.Value);
        }

        private void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus1.Text = TimeSpan.FromSeconds(sliProgress1.Value).ToString(@"hh\:mm\:ss");
        }

        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            mePlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }

        private void Element_MediaOpened(object sender, EventArgs e)
        {
            sliProgress1.Maximum = mePlayer.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

    }
}
