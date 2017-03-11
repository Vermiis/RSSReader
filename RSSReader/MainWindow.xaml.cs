using SimpleFeedReader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           // var posts = new Reader().ReadFeed(@"http://www.nytimes.com/services/xml/rss/nyt/International.xml");
           // Console.WriteLine(posts.ToList().Count);
          //  Console.ReadLine();
          //  FeedBox.Text = posts.ToList().ToString();

            var reader = new FeedReader();
            var items = reader.RetrieveFeed("http://www.nytimes.com/services/xml/rss/nyt/International.xml");
            string feeds=" " ;

            foreach (var i in items)
            {
                
                var x=(string.Format("{0}\t{1}",
                        i.Date.ToString("g"),
                        i.Title)
                
                );
                feeds += x;
            }
            FeedBox.Text = feeds;
        }
    }
}
