using AxWMPLib;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWAudioVideoPlayer.ViewModels
{
    public class VideoPlayerVm
    {
        public VideoPlayerVm()
        {
            SourcePath = new Uri(@"C:\Users\eliza\Downloads\Catherine_Part1.wmv");
            //Player = new AxWindowsMediaPlayer();
            //Player.BeginInit();
            //Player.EndInit();
            //Player.e          //  Player.CtlEnabled = true;
            //Player.openPlayer(@"C:\Users\eliza\Downloads\Catherine_Part1.wmv");
        }

        AxWindowsMediaPlayer Player { get; set; }

        public Uri SourcePath { get; set; }

        //private DelegateCommand _playVideoCommand;
        //public DelegateCommand PlayVideoCommand
        //{
        //    get { return _playVideoCommand; }
        //    set
        //    {
        //        if (_playVideoCommand != null)
        //            _playVideoCommand = new DelegateCommand(ShowScreen, CanPlayVideo);
        //    }
        //}

        private DelegateCommand _getFileNameCommand;
        public DelegateCommand GetFileNameCommand
        {
            get { return _getFileNameCommand = new DelegateCommand(GetFileName); }
        }

        private void GetFileName()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg)|*.mp3;*.mpg;*.mpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
                SourcePath = new Uri(openFileDialog.FileName);
        }
    }
}
