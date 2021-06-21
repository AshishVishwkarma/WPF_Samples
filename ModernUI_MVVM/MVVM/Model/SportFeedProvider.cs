using System;
using System.Threading;
using System.Threading.Tasks;

namespace ModernUI_MVVM.MVVM.Model
{
    class SportFeedProvider : Observable
    {
        private string _feed;

        public SportFeedProvider()
        {
            _thread = new Thread(new ThreadStart(trackFeed));
            _thread.Start();
        }

        private void trackFeed()
        {
            String[] Feeds = {
                "Sport feed One...",
                "Sport feed Two...",
                "Sport feed Three...",
                "Sport feed Four...",
                "Sport feed Five...",
                "Sport feed Six...",
                "Sport feed Seven...",
                "Sport feed Eight...",
                "Sport feed Nine...",
                "Sport feed Ten...",
            };

            Random rnd = new Random();

            while (true)
            {
                // Getting updated feed
                _feed = Feeds[rnd.Next(0, Feeds.Length)];

                publish(_feed);

                Thread.Sleep(2000); // 2 sec
            }
        }

        private Thread _thread;
    }
}
