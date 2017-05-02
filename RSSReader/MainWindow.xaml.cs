using System;
using System.Windows;


namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            RSSReader.Getter.xmel();
            InitializeComponent();
            Class.InicializeDataBase Init = new Class.InicializeDataBase();
            Init.inicjalizeDataBase();
            Post p = new Post();
            DataWriter.Write(p);
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
