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
            Class.InicializeDataBase Init = new Class.InicializeDataBase();
            Init.inicjalizeDataBase();
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
            Post wpis = new Post();
            wpis.Description = "Desc";
            wpis.link = "WWW";
            wpis.PublishedDate = DateTime.Now.ToString();

            DataWriter.ZapisTest(wpis);
        }
    }
}
