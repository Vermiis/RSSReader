using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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

    }

    public class TnijXML
    {
        public static List<string> GetLinksFromFile(string mark)
        {
            XmlDocument xml = new XmlDocument();
            List<string> vals = null;
            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "user.config");


            xml.Load(fileName);
            // xml.LoadXml(myXmlString);

            //"/ArrayOfString" lub "value"

            XmlNodeList xnList = xml.SelectNodes(mark);
            foreach (XmlNode xn in xnList)
            {
                string val = xn["String"].InnerText;

                vals.Add(val);
            }
            return vals;
            //jak time to trzeba będzie brać item zerowy

        }
    }
}
