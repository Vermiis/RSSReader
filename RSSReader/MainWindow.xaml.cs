﻿//using RSSReader.RSSReader;
using System;
using System.Windows.Controls;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Data.SqlClient;

namespace RSSReader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        public string HtmlAdress { get; set; }

        RSSTitle dataEntities = new RSSTitle();

        public MainWindow()
        {
            InitializeComponent();
            DataTimeConverter.ConvertDateTime("");
            DataWriter.WriteFeeds(Getter.xmel());
            FeedRss();
            Settings.SendPropFile();
            HideColumns();
        }
        void HideColumns()
        {
            //DG_RSSTitle.SetDetailsVisibilityForItem( SetDataBinding(ds, "Products")
            //DG_RSSTitle.Columns[1].Visibility = Visibility.Hidden;

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



        private void btn_Close_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btn_Settings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow Settings = new SettingsWindow();
            Settings.ShowDialog();
        }

        

        private void DG_RSSTitle_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            RTB_RSSDesc.Document.Blocks.Clear();
            var desc = DG_RSSTitle.CurrentCell.Item;
            try
            {
                string description = ((RSSReader.Feed)desc).Description;
                HtmlAdress = ((RSSReader.Feed)desc).Url;
                DescriptioncCut(description);
            }
            catch (System.Exception)
            {
            }
        }
        public void DescriptioncCut(string Desc)
        {
            string photo;
            string description;
            string[] temp = Desc.Split('>', '<');
            description = temp[2];
            temp = temp[1].Split('"');
            photo = temp[1];
            RTB_RSSDesc.Document.Blocks.Add(new Paragraph(new Run(description)));
            Img_article.Source = new BitmapImage(new Uri(photo));
        }
        public DataGridCell GetDataGridCell(DataGridCellInfo cellInfo)
        {
            var cellContent = cellInfo.Column.GetCellContent(cellInfo.Item);
            if (cellContent != null)
                return (DataGridCell)cellContent.Parent;

            return null;
        }


        private void btn_ShowArticle_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ReadRSSWindow Rss = new ReadRSSWindow(HtmlAdress);
                Rss.ShowDialog();
            }
            catch (System.Exception)
            {
            }
        }

        //private void button_Click(object sender, RoutedEventArgs e)
        //{
        //    using (SqlConnection cn = new SqlConnection())
        //    {
        //        cn.ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=RSSReader.Class.DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = cn;
        //        cmd.CommandType = CommandType.Text;
        //        cmd.CommandText = "DELETE FROM Feeds";
        //        cmd.ExecuteNonQuery();
        //        cn.Close();
        //    }
        //}
    }
}
