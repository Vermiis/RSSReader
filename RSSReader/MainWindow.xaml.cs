using System;
using System.Data.Entity.Core.Objects;
using System.Windows;


namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RSSTitle dataEntities = new RSSTitle();
       
        public MainWindow()
        {
            InitializeComponent();
            DataTimeConverter.ConvertDateTime("");
            Class.InicializeDataBase Init = new Class.InicializeDataBase();
            Init.inicjalizeDataBase();
            DataWriter.WriteFeeds(Getter.xmel());
            FeedRss();
        }
        void FeedRss()
        {

            DG_RSSTitle.ItemsSource = dataEntities.Feeds.Local;
            foreach (var feed in dataEntities.Feeds)
            {
                //int a = 0;
                //DG_RSSTitle.Items.Add = feed.Title.ToString();
                //a++;
            }
            //ObjectQuery<Feed> products = dataEntities.Feeds.Local;

            //var query =
            //from feed in products
            //where feed. == "Red"
            //orderby product.ListPrice
            //select new { product.Name, product.Color, CategoryName = product.ProductCategory.Name, product.ListPrice };

        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ReadRSSWindow Rss = new ReadRSSWindow();
            Rss.ShowDialog();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow Settings = new SettingsWindow();
            Settings.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
