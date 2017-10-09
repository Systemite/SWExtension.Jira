using SWExtension.Jira.Xml;
using System;
using SystemWeaver.ExtensionsAPI;

namespace SWExtension.Jira.Models
{
    public class ExtensionConfig
    {
        public string BaseUrl { get; set; }
        public string MainProject { get; set; }
        public string CustomField { get; set; }
        public string ItemType { get; set; }
        public string IssueType { get; set; }

        public ExtensionConfig(string xml)
        {
            if (!string.IsNullOrEmpty(xml))
            {
                JiraConfiguration jiraConf = JiraConfiguration.DeserializeCommunication(xml);
                BaseUrl = jiraConf.BaseUrl;
                MainProject = jiraConf.MainProject;
                CustomField = jiraConf.CustomField;
                ItemType = jiraConf.ItemType;
                IssueType = jiraConf.IssueType;
            }
        }
    }
}
