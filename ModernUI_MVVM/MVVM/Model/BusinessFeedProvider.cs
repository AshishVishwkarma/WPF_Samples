using System;
using System.Threading;

namespace ModernUI_MVVM.MVVM.Model
{
    class BusinessFeedProvider : Observable
    {
        private string _feed;

        public BusinessFeedProvider()
        {
            _thread = new Thread(new ThreadStart(TrackFeed));
            _thread.Start();
        }

        private void TrackFeed()
        {
            String[] Feeds = {
                "Business feed One...",
                "Business feed Two...",
                "Business feed Three...",
                "Business feed Four...",
                "Business feed Five...",
                "Business feed Six...",
                "Business feed Seven...",
                "Business feed Eight...",
                "Business feed Nine...",
                "Business feed Ten...",
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
