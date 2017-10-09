using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace SWExtension.Jira.Xml
{
    [Serializable]
    [XmlRoot]
    public class JiraConfiguration
    {
        [XmlElement]
        public string BaseUrl { get; set; }

        [XmlElement]
        public string MainProject { get; set; }

        [XmlElement]
        public string CustomField { get; set; }

        [XmlElement]
        public string ItemType { get; set; }

        [XmlElement]
        public string IssueType { get; set; }

        public static JiraConfiguration DeserializeCommunication(string xmlString)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(JiraConfiguration));
            using (TextReader reader = new StringReader(xmlString))
            {
                return (JiraConfiguration)serializer.Deserialize(reader);
            }
        }
    }
}
