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
            _timeSpan = TimeSpan.FromSeconds(0);

            Mode = TimerMode.Clock;

            _timer = new DispatcherTimer(new TimeSpan(0, 0, 1), DispatcherPriority.Normal, delegate
            {
                RefreshTimer();
            }, Application.Current.Dispatcher);
        }

        private void RefreshTimer()
        {
            switch (Mode)
            {
                case TimerMode.Next:
                    _timeSpan = _timeSpan.Add(TimeSpan.FromSeconds(1));
                    RefreshPrintedTime();
                    break;
                case TimerMode.Back:
                    _timeSpan = _timeSpan.Subtract(TimeSpan.FromSeconds(1));
                    RefreshPrintedTime();
                    break;
                case TimerMode.Clock:
                    RefreshPrintedCurrentTime();
                    break;
            }
        }

        private void RefreshPrintedTime()
        {
            CurrentTimeString = _timeSpan.ToString(@"mm\:ss");
        }

        private void RefreshPrintedCurrentTime()
        {
            CurrentTimeString = DateTime.Now.TimeOfDay.ToString(@"hh\:mm");
        }

        private DispatcherTimer _timer { get; set; }
        private DispatcherTimer _currentTime { get; set; }
        private TimeSpan _timeSpan { get; set; }

        private TimerMode Mode { get; set; }

        private string _currentTimeString;
        public string CurrentTimeString
        {
            get { return _currentTimeString; }
            set
            {
                _currentTimeString = value;
                OnPropertyChanged(() => CurrentTimeString);
            }
        }

        private DelegateCommand _stopTimerCommand;
        public DelegateCommand StopTimerCommand
        {
            get
            {
                return _stopTimerCommand = new DelegateCommand(StopTimer);
            }
        }

        private DelegateCommand _showCurrentTimeCommand;
        public DelegateCommand ShowCurrentTimeCommand
        {
            get
            {
                return _showCurrentTimeCommand = new DelegateCommand(ShowCurrentTime);
            }
        }

        private DelegateCommand _clearTimerCommand;
        public DelegateCommand ClearTimerCommand
        {
            get
            {
                return _clearTimerCommand = new DelegateCommand(ClearTimer);
            }
        }

        private DelegateCommand _rewindTimerCommand;
        public DelegateCommand RewindTimerCommand
        {
            get
            {
                return _rewindTimerCommand = new DelegateCommand(RewindTimer);
            }
        }

        private DelegateCommand _forwardTimerCommand;
        public DelegateCommand ForwardTimerCommand
        {
            get
            {
                return _forwardTimerCommand = new DelegateCommand(ForwardTimer);
            }
        }

        private DelegateCommand _startTimerCommand;
        public DelegateCommand StartTimerCommand
        {
            get
            {
                return _startTimerCommand = new DelegateCommand(StartTimer);
            }
        }

        private DelegateCommand _pauseTimerCommand;
        public DelegateCommand PauseTimerCommand
        {
            get
            {
                return _pauseTimerCommand = new DelegateCommand(PauseTimer);
            }
        }

        private void PauseTimer()
        {
            _timer.IsEnabled = false;
        }

        private void StartTimer()
        {
            Mode = TimerMode.Next;
            _timer.IsEnabled = true;
            _timer.Start();
        }

        private void RewindTimer()
        {
            _timeSpan = _timeSpan.Subtract(TimeSpan.FromSeconds(1));
            RefreshPrintedTime();
        }

        private void ForwardTimer()
        {
            _timeSpan = _timeSpan.Add(TimeSpan.FromSeconds(1));
            RefreshPrintedTime();
        }

        private void StopTimer()
        {
            _timer.Stop();
            _timeSpan = TimeSpan.Zero;
            RefreshPrintedTime();
        }

        private void ShowCurrentTime()
        {
            Mode = TimerMode.Clock;
        }

        private void ClearTimer()
        {
            _timeSpan = TimeSpan.Zero;
            RefreshPrintedTime();
        }
    }
}
