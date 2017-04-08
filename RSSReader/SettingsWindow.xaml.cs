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
        }

        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
