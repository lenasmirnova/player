using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JWAudioVideoPlayer.ViewModels
{
    public class MusicPlayerVm : BindableBase
    {
        #region Ctor
        public MusicPlayerVm()
        {
            SongList = new List<Song>();
            LyricList = new Dictionary<int, string>();

            InitializeLists();
        }
        #endregion

        #region Fields & Properties
        public List<Song> SongList { get; set; }
        public Dictionary<int, string> LyricList { get; set; }

        private Song _selectedSong;
        public Song SelectedSong
        {
            get { return _selectedSong; }
            set
            {
                if (value == _selectedSong)
                    return;
                _selectedSong = value;
                OnPropertyChanged(() => SelectedSong);
                SetLyrics();
            }
        }

        private string _selectedSongLyrics;
        public string SelectedSongLyrics
        {
            get { return _selectedSongLyrics; }
            set
            {
                if (value == _selectedSongLyrics)
                    return;
                _selectedSongLyrics = value;
                OnPropertyChanged(() => SelectedSongLyrics);
            }
        }
        #endregion

        #region Methods
        private void InitializeLists()
        {
            string lyricsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TEKST_PIESNI");
            string songsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "MELODIA_PIESNI");
          //  SelectedSongLyrics = @"C:\Users\Eliza&Robert\Desktop\TEKST_PIESNI\1.png";
            DirectoryInfo lyricsDirectory = new DirectoryInfo(lyricsPath);
            DirectoryInfo songsDirectory = new DirectoryInfo(songsPath);

            LoadSongs(songsDirectory);
            LoadLyrics(lyricsDirectory);
        }

        private void LoadSongs(DirectoryInfo songsDirectory)
        {
            songsDirectory.GetFiles().ToList().ForEach(x => SongList.Add(new Song(x.FullName, x.Name)));
        }

        private void LoadLyrics(DirectoryInfo lyricsDirectory)
        {
            foreach (var fileInfo in lyricsDirectory.GetFiles())
            {
                int number = 0;
                string[] splittedName = fileInfo.Name.Split('.');
                if (Int32.TryParse(splittedName[0], out number))
                {
                    LyricList.Add(number, fileInfo.FullName);
                }
            }
        }

        private void SetLyrics()
        {
            string foundPath = string.Empty;
            if (!LyricList.TryGetValue(SelectedSong.Number, out foundPath))
            {
                throw new InvalidOperationException("Nie znaleziono tekstu wybranej pieśni.");
            }
            SelectedSongLyrics = foundPath;
        }
        #endregion
    }
}
