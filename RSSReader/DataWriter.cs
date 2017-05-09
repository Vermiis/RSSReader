using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace RSSReader
{
    class DataWriter
    {
        public static object XmlDisplay { get; private set; }

        public static void WriteFeeds(List<Post> Posts)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = @"Data Source=LOCALHOST\SQLEXPRESS;Initial Catalog=RSSReader.Class.DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

                cn.Open();
                foreach (var post in Posts)
                {
                    Write(post, cn);
                }

                cn.Close();
            }
        }   

        public static void Write(Post post, SqlConnection cn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO Feeds(Date, Title, Description, Url) VALUES (@DataTime, @Title, @Description, @Url)";
            cmd.Parameters.AddWithValue("@DataTime", post.PublishedDate);
            cmd.Parameters.AddWithValue("@Title", post.Title);
            cmd.Parameters.AddWithValue("@Description", post.Description);
            cmd.Parameters.AddWithValue("@Url", post.Link);
            cmd.ExecuteNonQuery();
        }
    }
}
