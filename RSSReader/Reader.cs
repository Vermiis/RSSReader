using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Xml.Linq;

namespace RSSReader
{

  //  public class Reader
    //{
    //    public IEnumerable<Post> ReadFeed(string url)
    //    {
    //        var rssFeed = XDocument.Load(url);

    //        var posts = from item in rssFeed.Descendants("item")
    //                    select new Post
    //                    {
    //                        Title = item.Element("title").Value,
    //                        Description = item.Element("description").Value,
    //                        PublishedDate = item.Element("pubDate").Value
    //                    };

    //        return posts;
    //    }

        //nietest
        //zmiana
 //   }
//


        public class Reader
    {
        public static string Feeds()
        {

            var reader = new FeedReader();
            var items = reader.RetrieveFeed("http://www.nytimes.com/services/xml/rss/nyt/International.xml");
            string feeds = "";

            foreach (var i in items)
            {

                var x = (string.Format("{0}\t{1}",
                        i.Date.ToString("g"),
                        i.Title)

                );
                feeds += x + "\n";
            }
            return feeds;
        }
    }

    public class Post
    {
        public string PublishedDate;
        public string Description;
        public string Title;
   
    }

    public class Refresher
    {
        void RefreshConfTimer(int val)
        {
            // Create a timer
            var myTimer = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every five seconds
            myTimer.Interval = val;
            // And start it        
            myTimer.Enabled = true;
        }

// Implement a call with the right signature for events going off
        private void myEvent(object source, ElapsedEventArgs e)
        {
            
        }
    
    }

    
}
