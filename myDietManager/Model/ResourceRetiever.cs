using System.Linq;
using System.Xml;

namespace myDietManager.Model
{
    public class ResourceRetiever
    {
        public XmlDocument XmlFile { get; set; }

        public void LoadXmlDocument()
        {
            this.XmlFile = new XmlDocument();
            this.XmlFile.Load("Resources.xml");

        }

        public string RetrieveActivityLevel(string activityLevelNumber)
        {
            this.LoadXmlDocument();

            XmlNodeList nodeList = this.XmlFile.SelectNodes("ActivityLevel/level");

            return nodeList != null ? nodeList.OfType<XmlNode>().Where(node => node.Attributes != null && node.Attributes["name"].Value == activityLevelNumber).Select(node => node.InnerText).First().Trim() : null;
        }
    }
}
