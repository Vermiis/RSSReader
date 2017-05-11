using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;

namespace RSSReader
{
    class Settings
    {

        public XmlDocument XmlDoc;

        public Settings()
        {
            XmlDoc = new XmlDocument();
        }

        public bool LoadFile(string PathFile)
        {
            try
            {
                XmlDoc.Load(PathFile);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string GetSettingByName(string Name)
        {
            XmlNodeList Settings = XmlDoc.SelectNodes("//userSettings//RSSReader.Properties.Settings//setting[@name = '" + Name + "']//value");
            foreach (XmlNode xn in Settings)
            {
                if (xn.HasChildNodes)
                {
                    return xn.InnerText;
                }
            }
            return null;
        }
        public static void SendPropFile()
        {
            string props;
            
            props = Properties.Settings.Default.Refresh.ToString();
            props += ";";
            props += Properties.Settings.Default.Link;
            System.IO.File.WriteAllText(@"C:\Users\"+Environment.UserName+@"\AppData\Local\RSSReader\Settings.txt", props);
        }
    }

    public class TnijXML
    {
        public static List<string> FindValues()
        {
            string text = System.IO.File.ReadAllText(@"C:\Users\" + Environment.UserName + @"\AppData\Local\RSSReader\Settings.txt").ToString();
            char[] delimiterChars = { ';' };



            string[] words = text.Split(delimiterChars);
            List<string> Wordz = new List<string>();


            foreach (string s in words)
            {

                Wordz.Add(s);


            }
            return Wordz;



        }

    }

    

}