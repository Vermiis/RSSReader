using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSSReader
{
    class DataTimeConverter
    {
        public static string ConvertDateTime(string DataTime)
        {
            DataTime = DataTime.Replace(".","-");
            return DataTime;
        }
    }
}
