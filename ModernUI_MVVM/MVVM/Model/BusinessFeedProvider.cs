using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Text.Json; // Install "System.Text.Json" NuGet Package [https://www.nuget.org/packages/System.Text.Json]
using System.Collections.Generic;


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

        private async void TrackFeed()
        {
            //String[] Feeds = { 
            //    "Business feed One...",
            //    "Business feed Two...",
            //    "Business feed Three...",
            //    "Business feed Four...",
            //    "Business feed Five...",
            //    "Business feed Six...",
            //    "Business feed Seven...",
            //    "Business feed Eight...",
            //    "Business feed Nine...",
            //    "Business feed Ten...",
            //};

            //Random rnd = new Random();

            //while (true)
            //{
            //    // Getting updated feed
            //    _feed = Feeds[rnd.Next(0, Feeds.Length)];

            //    publish(_feed);

            //    Thread.Sleep(2000); // 2 sec
            //}

            while (true)
            {
                try
                {
                    //await ProcessFeed();
                    var feeds = await ProcessFeed();

                    foreach (var feed in feeds)
                    {
                        _feed = feed.headline;

                        publish(_feed);

                        Thread.Sleep(2000); // 2 sec
                    }
                }
                catch (Exception)
                {
                    Thread.Sleep(5000); // 2 sec
                }

            }
        }

        //private static async Task<List<Feed>> ProcessFeed()
        private static async Task<List<BusinessFeed>> ProcessFeed()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); // Internet media type for JSON
                //new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
                
            //client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            string URL = "http://localhost:1234/business_feed";
            //string URL = "https://api.github.com/orgs/dotnet/repos";

            //var stringTask = client.GetStringAsync("http://localhost:1234/business_feed");
            //var msg = await stringTask;
            //MessageBox.Show(msg);


            var streamTask = client.GetStreamAsync(URL);
            var result = await streamTask;
            var feeds = await JsonSerializer.DeserializeAsync<List<BusinessFeed>>(result);
           
            //MessageBox.Show(feeds[0].headline);

            return feeds;
        }

        private Thread _thread;
        private static readonly HttpClient client = new HttpClient();
    }

    public class BusinessFeed
    {
        public int id { get; set; }

        public string headline { get; set; }

    }
}
