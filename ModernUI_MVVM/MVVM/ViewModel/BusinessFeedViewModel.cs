using ModernUI.Core;
using ModernUI_MVVM.MVVM.Model;
using System;


namespace ModernUI.MVVM.ViewModel
{
    class BusinessFeedViewModel : ViewModelBase, IObserver<string>
    {
        public string CurrentBusinessFeed 
        {
            get { return _currentFeed != null ? _currentFeed : "Feed is not avaliable!"; }
            set 
            {
                if (value == _currentFeed) return;

                _currentFeed = value;
                base.OnPropertyChanged("CurrentBusinessFeed");
            }
        }

        private BusinessFeedProvider _businessFeedProvider;
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
            CurrentBusinessFeed = value;
        }

        public BusinessFeedViewModel()
        {
            _businessFeedProvider = new BusinessFeedProvider();
            _unsubscriber = _businessFeedProvider.Subscribe(this);

            // For test
            //OnNext("Expand your business...");
        }
    }
}
