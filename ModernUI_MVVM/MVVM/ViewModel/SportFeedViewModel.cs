using ModernUI.Core;
using ModernUI_MVVM.MVVM.Model;
using System;


namespace ModernUI.MVVM.ViewModel
{
    class SportFeedViewModel : ViewModelBase, IObserver<string>
    {
        public string CurrentSportFeed
        {
            get { return _currentFeed != null ? _currentFeed : "Feed is not avaliable!"; }
            set
            {
                if (value == _currentFeed) return;

                _currentFeed = value;
                base.OnPropertyChanged("CurrentSportFeed");
            }
        }

        private SportFeedProvider _sportFeedProvider;
        private IDisposable _unsubscriber;

        private string _currentFeed;

        public void OnCompleted()
        {
            _unsubscriber.Dispose();
        }
        public void OnError(Exception error)
        {

        }
        public void OnNext(string value)
        {
            CurrentSportFeed = value;
        }

        public SportFeedViewModel()
        {
            _sportFeedProvider = new SportFeedProvider();
            _unsubscriber = _sportFeedProvider.Subscribe(this);
        }
    }
}
