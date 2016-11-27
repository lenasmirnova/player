using Microsoft.Win32;
using Prism.Commands;
using System;

namespace JWAudioVideoPlayer.ViewModels
{
    public class VideoPlayerVm
    {
        public VideoPlayerVm()
        {
            SourcePath = "ddd";
        }
        //      
        // public Uri SourcePath { get; set; }
        public string SourcePath { get; set; }
        //private DelegateCommand _getFileNameCommand;
        //public DelegateCommand GetFileNameCommand  
        //{
        //    get { return _getFileNameCommand = new DelegateCommand(GetFileName); }
        //}

        //private void GetFileName()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog() == true)
        //        SourcePath = new Uri(openFileDialog.FileName);
        //}
    }
}
