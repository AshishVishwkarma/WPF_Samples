using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUI_MVVM.MVVM.Model
{
    class Observable : IObservable<string>
    {
        private List<IObserver<string>> _observers;

        public Observable()
        {
            _observers = new List<IObserver<string>>();
        }

        public void publish(string message)
        {
            foreach (var observer in _observers.ToArray())
                observer.OnNext(message);
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if (!_observers.Contains(observer))
                _observers.Add(observer);
            return new Unsubscriber(_observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<string>> _observers;
            private IObserver<string> _observer;

            public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }

        
    }
}
