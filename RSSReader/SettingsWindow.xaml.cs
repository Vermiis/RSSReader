using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        void LoadData()
        {
            tb_Link.Text = Properties.Settings.Default.Link;
            tb_refreshTime.Text = Properties.Settings.Default.Refresh.ToString();

        }
        private void tb_Link_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            //TODO zapis do bazy
            System.Data.SqlClient.SqlConnection MSDEconn;
            MSDEconn = new SqlConnection();
            //TODO connection string
            MSDEconn.ConnectionString = @"workstation id=KOMPUTER; packet size=4096; integrated security=SSPI; data source=KOMPUTER\NASZA_BAZA; persist security info=False; initial catalog=baza_testowa";
            MSDEconn.Open();
            System.Data.SqlClient.SqlCommand MSDEcommand = new SqlCommand();
            MSDEcommand.Connection = MSDEconn;
            MSDEcommand.CommandText = "INSERT INTO [IDUserIDCategory] ([UserID], [UrlID]) VALUES (NULL, "+tb_Link.Text+")";
            MSDEcommand.ExecuteNonQuery();
            MSDEconn.Close();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {
            int refreshTime;
            bool res = int.TryParse(tb_refreshTime.Text.ToString(), out refreshTime);
            if (tb_refreshTime.Text !="" && tb_Link.Text!="" && res==true)
            {
                Properties.Settings.Default.Link = tb_Link.Text.ToString();
                Properties.Settings.Default.Refresh = refreshTime;
                Properties.Settings.Default.Save();
                MessageBox.Show("Zapisano");
            }
            else
            {
                MessageBox.Show("Wpisane wartości nie są prawidłowe");
            }
            
        }
    }
}
