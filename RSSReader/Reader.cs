using SimpleFeedReader;
using System.Collections.Generic;
using System.Timers;
using System.Xml;
using System.Linq;
using System.Windows.Forms;
using System.ServiceModel.Syndication;
using System.Globalization;
using System;

namespace RSSReader
{
    namespace RSSReader
    {
    public class Reader
    {
        // Pytanie, czym się różni funcja Feeds() od xmel(), mam wrażenie że obie realizują to samo zadanie.
        public static string Feeds()
        {
            var reader = new FeedReader();
            // Docelowo dane zaczytywane od użytkownika
            var items = reader.RetrieveFeed("http://www.nytimes.com/services/xml/rss/nyt/International.xml");
            string feeds = "";
            foreach (var i in items)
            {
                var x = (string.Format("{0}\t{1}", i.Date.ToString("g"), i.Title)
                );
                feeds += x + "\n";
            }
            return feeds;
        }
    }


    public class Getter
    {
        public static List<Post> xmel()
        {
            var feedsList = new List<Post>();
            List<string> UrlList = new List<string>();
           // UrlList.Add("http://www.tvn24.pl/najnowsze.xml");
            UrlList.Add("http://wiadomosci.wp.pl/ver,rss,rss.xml");
           // UrlList.Add("http://www.tvn24.pl/biznes-gospodarka,6.xml");
            UrlList.Add("http://fakty.interia.pl/feed");

            foreach (var link in UrlList)
            {
                XmlReader reader = XmlReader.Create(link);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (var item in feed.Items)
                {
                    Post post = new Post(DateTime.Now);
                    post.Title = item.Title.Text;
                    post.Description = item.Summary.Text;
                    post.PublishedDate = item.PublishDate.DateTime;
                    post.Link = item.Links[0].Uri.ToString();                       
                    feedsList.Add(post);              
                }
                
            }
            return feedsList;
        }
    }

    public class RSSRefresher
    {
        public static System.Timers.Timer _timer;

        public static void RSSRefresherFunc()
        {
            _timer = new System.Timers.Timer(60000);
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Getter.xmel();
            MessageBox.Show("The Elapsed event was raised at {0:HH:mm:ss.fff}" + e.SignalTime);
        }
    }



}