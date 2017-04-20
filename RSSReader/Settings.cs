using System;
using System.Collections.Generic;
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
}
