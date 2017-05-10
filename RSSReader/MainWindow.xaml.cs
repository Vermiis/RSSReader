//using RSSReader.RSSReader;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
            DataWriter.WriteFeeds(Getter.xmel());
            FeedRss();
            Settings.SendPropFile();
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
            //this.DG_RSSTitle.Columns[0].Visibility = Visibility.Hidden;
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

        private void DG_RSSTitle_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RTB_RSSDesc.Document.Blocks.Clear();
            var test=DG_RSSTitle.CurrentCell.Item;
            string description = ((RSSReader.Feed)test).Description;
            RTB_RSSDesc.Document.Blocks.Add(new Paragraph(new Run(description)));
        }
        public DataGridCell GetDataGridCell(DataGridCellInfo cellInfo)
        {
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            if (cellContent != null)
                return (DataGridCell)cellContent.Parent;

            return null;
        }
    }
}
