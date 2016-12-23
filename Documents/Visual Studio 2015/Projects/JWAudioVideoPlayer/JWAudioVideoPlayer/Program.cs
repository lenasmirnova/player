using JWAudioVideoPlayer.ViewModels;
using JWAudioVideoPlayer.Views;
using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;

namespace JWAudioVideoPlayer
{
    public class Program : BindableBase
    {
        #region Ctor
        public Program()
        {
            Timer = new TimerVm();
            VideoPlayer = new VideoPlayerVm();
            MusicPlayer = new MusicPlayerVm();
        }
        #endregion

        #region Fields & Properties

        public TimerVm Timer { get; set; }
        public VideoPlayerVm VideoPlayer { get; set; }
        public MusicPlayerVm MusicPlayer { get; set; }

        public ProjectorWindowV ProjectorWindow { get; set; }

        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (value == _selectedTabIndex)
                    return;
                _selectedTabIndex = value;
                OnPropertyChanged(() => SelectedTabIndex);
            }
        }

        private int _projectedTabIndex;
        public int ProjectedTabIndex
        {
            get { return _projectedTabIndex; }
            set
            {
                if (value == _projectedTabIndex)
                    return;
                _projectedTabIndex = value;
                OnPropertyChanged(() => ProjectedTabIndex);
            }
        }

        private bool _projectorEnabled;
        public bool ProjectorEnabled
        {
            get { return _projectorEnabled; }
            set
            {
                if (value == _projectorEnabled)
                    return;
                _projectorEnabled = value;
                OnPropertyChanged(() => ProjectorEnabled);
            }
        }

        #region Commands
        private DelegateCommand _showSecondScreenCommand;
        public DelegateCommand ShowSecondScreenCommand
        {
            get { return _showSecondScreenCommand = new DelegateCommand(ShowScreen); }
        }

        private DelegateCommand _closeSecondScreenCommand;
        public DelegateCommand CloseSecondScreenCommand
        {
            get { return _closeSecondScreenCommand = new DelegateCommand(CloseScreen); }
        }
        #endregion
        #endregion

        #region Methods
        private void ShowScreen()
        {
            ProjectedTabIndex = SelectedTabIndex;
            
            //if (ProjectorWindow == null || !ProjectorWindow.IsActive)
            if (ProjectorWindow == null)
            {
                ProjectorWindow = new ProjectorWindowV();
                ProjectorWindow.DataContext = this;
            }
            if (!ProjectorEnabled)
            { 
                ProjectorWindow.ShowOnSecondScreen();
            }
            ProjectorEnabled = true;
        }
        
        private void CloseScreen()
        {
            ProjectorEnabled = false;
            if (ProjectorWindow != null)
            {
                ProjectorWindow.Hide();
            }
        }

        internal void OnWindowClosing(object sender, CancelEventArgs e)
        {
            if (ProjectorWindow != null)
                ProjectorWindow.Close();
        }
        #endregion 
    }
}
