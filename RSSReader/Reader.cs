using SimpleFeedReader;
using System.Collections.Generic;
using System.Timers;
using System.Xml;
using System.Windows.Forms;
using System.ServiceModel.Syndication;

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
                var x = (string.Format("{0}\t{1}",
                        i.Date.ToString("g"),
                        i.Title)
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
            UrlList.Add("http://wiadomosci.wp.pl/ver,rss,rss.xml");
           // UrlList.Add("http://www.tvn24.pl/najnowsze.xml");
           // UrlList.Add("http://www.tvn24.pl/biznes-gospodarka,6.xml");
           // UrlList.Add("http://fakty.interia.pl/feed");

            foreach (var link in UrlList)
            {
                XmlReader reader = XmlReader.Create(link);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                foreach (var item in feed.Items)
                {
                    Post post = new Post();
                    post.Title = item.Title.Text;
                    post.Description = item.Summary.Text;
                    post.PublishedDate = DataTimeConverter.ConvertDateTime(item.PublishDate.DateTime.ToString());
                    post.Link = "";
                    feedsList.Add(post);              
                }
                
            }
            return feedsList;
        }
    }

    #region cutter
    //public class Cutter
    //{
    //    public static Post Posts(IEnumerable<FeedItem> x)
    //    {
    //        XmlDocument doc = new XmlDocument();
    //        doc.Load("c:\\temp.xml");
    //        var pos = new Post();
    //        foreach (XmlNode node in doc.DocumentElement.ChildNodes)
    //        {
    //            string text = node.InnerText; //or loop through its children as well
    //            string attr = node.Attributes["link"]?.InnerText;
    //        }

    //        return;


    //    }
    //}
    #endregion


    public class Refresher
    {
        void RefreshConfTimer(int val)
        {
            // Create a timer
            var myTimer = new System.Timers.Timer();
            // Tell the timer what to do when it elapses
            myTimer.Elapsed += new ElapsedEventHandler(myEvent);
            // Set it to go off every val seconds
            myTimer.Interval = val;
            // And start it        
            myTimer.Enabled = true;
            // ma pobierać VAL z GUI i wedle wpisanej watosci wywolywac funkcje pobierajaca feed'y
        }

        // Implement a call with the right signature for events going off
        private void myEvent(object source, ElapsedEventArgs e)
        {

        }
    }

    public class TnijXML
    {
        public static List<string> GetLinksFromFile(string myXmlString)
        {
            XmlDocument xml = new XmlDocument();
            List<string> linki = null;
            xml.LoadXml(myXmlString);

            XmlNodeList xnList = xml.SelectNodes("/ArrayOfString");
            foreach (XmlNode xn in xnList)
            {
                string link = xn["String"].InnerText;

                linki.Add(link);
            }
            return linki;

        }
    }

}