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
        readonly System.Timers.Timer _timer;
        public RSSRefresher()
        {
            _timer = new System.Timers.Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Getter.xmel();
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }

}