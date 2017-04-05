using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RSSReader
{
    class DataWriter
    {


        public static void Write()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=[server_name];Database=[database_name];Trusted_Connection=true";
                // using the code here...
            }
        }



    }
}
