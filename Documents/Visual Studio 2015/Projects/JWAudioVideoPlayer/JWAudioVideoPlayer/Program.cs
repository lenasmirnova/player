using JWAudioVideoPlayer.ViewModels;
using JWAudioVideoPlayer.Views;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWAudioVideoPlayer
{
    public class Program
    {
        #region Ctor
        public Program()
        {
            Timer = new TimerVm();
            VideoPlayer = new VideoPlayerVm();
        }
        #endregion

        #region Fields & Properties

        public TimerVm Timer { get; set; }
        public VideoPlayerVm VideoPlayer { get; set; }
        public MusicPlayerVm MusicPlayer { get; set; }

        public ProjectorWindowV ProjectorWindow { get; set; }

        #region Commands
        private DelegateCommand _showSecondScreenCommand;
        public DelegateCommand ShowSecondScreenCommand
        {
            get { return _showSecondScreenCommand = new DelegateCommand(ShowScreen); }
        }
        #endregion
        #endregion

        #region Methods

        private void ShowScreen()
        {
            var window = new ProjectorWindowV();
            window.DataContext = this;
            window.ShowOnSecondScreen();
        }
        #endregion
    }
}
