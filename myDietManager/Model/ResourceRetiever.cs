using System;
using System.Collections;
using System.Collections.Generic;
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

        public Dictionary<int, string> RetrieveActivityLevelDescription()
        {
            this.LoadXmlDocument();

            var nodeList = this.XmlFile.SelectNodes("ActivityLevel/level");

            return nodeList?.OfType<XmlNode>()
                .ToDictionary(node => Convert.ToInt32(node.Attributes?["Name"].Value), node => node.InnerText);
        }
    }
}
