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

        public static void Write(Post post)
        {
            using (SqlConnection cn = new SqlConnection())
            {
                Post TestPost = new Post();
                TestPost.PublishedDate = "1992-12-12 22:22:22";
                TestPost.Title = "SomeTestTitle";
                TestPost.Description = "SomeDesc";
                TestPost.link = "www.google.pl";
                post = TestPost;
                cn.ConnectionString = @"Data Source=DESKTOP-KEKK5K0\SQLEXPRESS;Initial Catalog=RSSReader.Class.DataBase;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";

                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText= "INSERT INTO Feeds(Date, Title, Description, Url) VALUES (@DataTime, @Title, @Description, @Url)";
                cmd.Parameters.AddWithValue("@DataTime", post.PublishedDate);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@Description", post.Description);
                cmd.Parameters.AddWithValue("@Url", post.link);
                cmd.ExecuteNonQuery();
                cn.Close();
            }
        }   
    }
}
