using Newtonsoft.Json;
using SWExtension.Jira.Common;
using System.Collections.Generic;
using System.Diagnostics;
using SystemWeaver.ExtensionsAPI;

namespace SWExtension.Jira.Models
{
    public class JiraCommands
    {
        private readonly string _issueUrl = "/rest/api/latest/issue/";
        private readonly string _searchUrl = "/rest/api/2/search?jql=text ~ ";
        private readonly string _createUrl = "/rest/api/2/issue/";
        private readonly string _browseUrl = "/browse/";

        // Usually something like: "customfield_10200"
        // This should be a custom field in Jira of type "string", intended for the storage of the SystemWeaver item url.
        private string _customField;

        // Base url to the SystemWeaver server, like: 'url:swap://hostname:443/'
        public string ItemBaseUrl { get; set; }

        // Base url to the Jira server, example: "http://localhost:8080" 
        public string JiraBaseUrl { get; private set; }

        // The name of the Jira project connected to SystemWeaver
        public string JiraProjectName { get; private set; }

        // The type of issue to create in Jira
        public string JiraIssueType { get; private set; }

        public string Password { get; set; }

        public string UserName { get; set; }

        public JiraCommands(string baseUrl, string project, string issueType, string customfield)
        {
            JiraBaseUrl = baseUrl.TrimEnd('/');
            JiraProjectName = project;
            JiraIssueType = issueType;
            _customField = customfield;
        }

        public JiraRoot GetIssue(string issue)
        {
            string json = RestUtility.GetJson(JiraBaseUrl + _issueUrl + issue, UserName, Password);

            return JsonConvert.DeserializeObject<JiraRoot>(json);
        }

        public List<Issue> SearchIssues(IswItem item)
        {
            string json = RestUtility.GetJson(JiraBaseUrl + _searchUrl + "\"" + ItemBaseUrl + item.HandleStr + "\"", UserName, Password);

            IssuesResult result = JsonConvert.DeserializeObject<IssuesResult>(json);

            if (result == null)
                return new List<Issue>();

            return result.issues;
        }

        public void OpenIssue(JiraIssue issue)
        {
            Process.Start(JiraBaseUrl + _browseUrl + issue.Key);
        }

        public JiraRoot CreateIssue(IswItem item)
        {
            var postData = CreateIssueFields(item);
            string json = JsonConvert.SerializeObject(postData);
            json = RestUtility.PostJson(JiraBaseUrl + _createUrl, json, UserName, Password);

            return JsonConvert.DeserializeObject<JiraRoot>(json);
        }

        private JiraPostRoot CreateIssueFields(IswItem item)
        {
            return new JiraPostRoot()
            {
                fields = new Dictionary<string, object>
                { 
                    { "project", new JiraPostProject() { key = JiraProjectName } },
                    { "summary", item.Name },
                    { "description", GetDescription(item) },
                    { "issuetype", new JiraPostIssuetype() { name = JiraIssueType } },
                    { _customField, ItemBaseUrl + item.HandleStr }
                }
            };
        }

        private string GetDescription(IswItem item)
        {
            byte[] data = item.Description.Data;
            string desc = SWUtility.RvfzToPlainText(data, item.Broker);

            // Replace all line breaks with \r\n in order to keep formatting.
            string lineSeparator = ((char)0x2028).ToString();
            string paragraphSeparator = ((char)0x2029).ToString();

            desc = desc.Replace(lineSeparator, "\r\n")
                       .Replace(paragraphSeparator, "\r\n");

            return desc;
        }
    }
}
