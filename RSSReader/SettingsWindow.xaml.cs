using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
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
        StringCollection CreateCollection()
        {
            StringCollection Link = new StringCollection();
            //var Link = new List<string>();
            string value =tb_Link.Text.ToString();
            Char delimiter = ';';
            String[] substrings = value.Split(delimiter);
            Link.AddRange(substrings);
            //foreach (var substring in substrings)
            //{
            //    Link.Add(substring);
            //}
            return Link;
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
            if (tb_refreshTime.Text=="clear")
            {
                using (SqlConnection cn = new SqlConnection())
                {
                    cn.ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=RSSReader.Class.DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "DELETE FROM Feeds";
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
            }
            bool res = int.TryParse(tb_refreshTime.Text.ToString(), out refreshTime);
            if (tb_refreshTime.Text !="" && tb_Link.Text!="" && res==true && refreshTime>0)
            {
                Properties.Settings.Default.Link = tb_Link.Text.ToString();
                Properties.Settings.Default.LinkColection = CreateCollection();
                Properties.Settings.Default.Refresh = refreshTime;
                Properties.Settings.Default.Save();
                MessageBox.Show("Zapisano");
                Settings.SendPropFile();

            }
            else
            {
                MessageBox.Show("Wpisane wartości nie są prawidłowe");
            }
            
        }

        private void tb_Link_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
