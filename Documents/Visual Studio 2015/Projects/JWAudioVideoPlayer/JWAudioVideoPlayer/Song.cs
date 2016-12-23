using System;

namespace JWAudioVideoPlayer
{
    public class Song
    {
        #region Ctor
        public Song(string path, string title)
        {
            Path = path;
            Title = GetTitle(title);
            Number = GetSongNumber();
        }
        #endregion

        #region Fields & Properties
        public int Number { get; set; }
        public string Title { get; set; }
        public string Path { get; set; }
        #endregion

        #region Methods
        private int GetSongNumber()
        {
            int number = 0;
            if (string.IsNullOrEmpty(Title) || Title.Length < 4)
                throw new ArgumentException("Nieprawidłowy opis pliku.");

            string numberToParse = Title.Substring(0, 3);
            if (!Int32.TryParse(numberToParse, out number))
            {
                throw new ArgumentException("Niemożliwe określenie numeru pieśni.");
            }

            return number;
        }

        private string GetTitle(string title)
        {
            if (title.Contains(".mp3"))
                title = title.Replace(".mp3", string.Empty);

            return title;
        }
        #endregion
    }
}
  