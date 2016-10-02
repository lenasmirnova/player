using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows;
using System.Windows.Threading;

namespace JWAudioVideoPlayer.ViewModels
{
    public class TimerVm : BindableBase
    {
        public TimerVm()
        {
            _timeSpan = TimeSpan.FromSeconds(120);

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                RefreshPrintedTime();
              //  if (_timeSpan == TimeSpan.Zero) _timer.Stop();
                _timeSpan = _timeSpan.Add(TimeSpan.FromSeconds(-1));
            }, Application.Current.Dispatcher);

            _timer.Start();
        }

        private void RefreshPrintedTime()
        {
            CurrentTimeString = _timeSpan.ToString("c");
        }

        private DispatcherTimer _timer { get; set; }
        private TimeSpan _timeSpan { get; set; }

        private string _currentTimeString;
        public string CurrentTimeString
        {
            get { return _currentTimeString; }
            set
            {
                this._currentTimeString = value;
                OnPropertyChanged(() => CurrentTimeString);
            }
        }

        private DelegateCommand _stopTimerCommand;
        public DelegateCommand StopTimerCommand
        {
            get
            {
                return  _stopTimerCommand = new DelegateCommand(StopTimer);
            }
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timeSpan = TimeSpan.Zero;
            RefreshPrintedTime();
        }
    }
}
