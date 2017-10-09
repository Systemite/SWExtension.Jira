using System.Collections.Generic;

namespace SWExtension.Jira.Models
{
    public class Issuetype
    {
        public string self { get; set; }
        public string id { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public bool subtask { get; set; }
        public int avatarId { get; set; }
    }

    public class AvatarUrls
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Project
    {
        public string self { get; set; }
        public string id { get; set; }
        public string key { get; set; }
        public string name { get; set; }
        public AvatarUrls avatarUrls { get; set; }
    }

    public class Timetracking
    {
    }

    public class Watches
    {
        public string self { get; set; }
        public int watchCount { get; set; }
        public bool isWatching { get; set; }
    }

    public class AvatarUrls2
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Creator
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls2 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class AvatarUrls3
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Reporter
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls3 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class Aggregateprogress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Priority
    {
        public string self { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
    }

    public class Progress
    {
        public int progress { get; set; }
        public int total { get; set; }
    }

    public class Comment
    {
        public List<object> comments { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public int startAt { get; set; }
    }

    public class Votes
    {
        public string self { get; set; }
        public int votes { get; set; }
        public bool hasVoted { get; set; }
    }

    public class Worklog
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<object> worklogs { get; set; }
    }

    public class AvatarUrls4
    {
        public string __invalid_name__48x48 { get; set; }
        public string __invalid_name__24x24 { get; set; }
        public string __invalid_name__16x16 { get; set; }
        public string __invalid_name__32x32 { get; set; }
    }

    public class Assignee
    {
        public string self { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string emailAddress { get; set; }
        public AvatarUrls4 avatarUrls { get; set; }
        public string displayName { get; set; }
        public bool active { get; set; }
        public string timeZone { get; set; }
    }

    public class StatusCategory
    {
        public string self { get; set; }
        public int id { get; set; }
        public string key { get; set; }
        public string colorName { get; set; }
        public string name { get; set; }
    }

    public class Status
    {
        public string self { get; set; }
        public string description { get; set; }
        public string iconUrl { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        public StatusCategory statusCategory { get; set; }
    }

    public class Fields
    {
        public Issuetype issuetype { get; set; }
        public List<object> components { get; set; }
        public object timespent { get; set; }
        public object timeoriginalestimate { get; set; }
        public string description { get; set; }
        public Project project { get; set; }
        public List<object> fixVersions { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolution { get; set; }
        public Timetracking timetracking { get; set; }
        public object customfield_10006 { get; set; }
        public object customfield_10200 { get; set; }
        public List<object> attachment { get; set; }
        public object aggregatetimeestimate { get; set; }
        public object resolutiondate { get; set; }
        public int workratio { get; set; }
        public string summary { get; set; }
        public string lastViewed { get; set; }
        public Watches watches { get; set; }
        public Creator creator { get; set; }
        public List<object> subtasks { get; set; }
        public string created { get; set; }
        public Reporter reporter { get; set; }
        public string customfield_10000 { get; set; }
        public Aggregateprogress aggregateprogress { get; set; }
        public Priority priority { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10002 { get; set; }
        public List<object> labels { get; set; }
        public object environment { get; set; }
        public object timeestimate { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public List<object> versions { get; set; }
        public object duedate { get; set; }
        public Progress progress { get; set; }
        public Comment comment { get; set; }
        public List<object> issuelinks { get; set; }
        public Votes votes { get; set; }
        public Worklog worklog { get; set; }
        public Assignee assignee { get; set; }
        public string updated { get; set; }
        public Status status { get; set; }
    }

    public class Timetracking2
    {
    }

    public class Comment2
    {
        public List<object> comments { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public int startAt { get; set; }
    }

    public class Worklog2
    {
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<object> worklogs { get; set; }
    }

    public class RenderedFields
    {
        public object issuetype { get; set; }
        public object components { get; set; }
        public object timespent { get; set; }
        public object timeoriginalestimate { get; set; }
        public string description { get; set; }
        public object project { get; set; }
        public object fixVersions { get; set; }
        public object aggregatetimespent { get; set; }
        public object resolution { get; set; }
        public Timetracking2 timetracking { get; set; }
        public object customfield_10006 { get; set; }
        public List<object> attachment { get; set; }
        public object aggregatetimeestimate { get; set; }
        public object resolutiondate { get; set; }
        public object workratio { get; set; }
        public object summary { get; set; }
        public string lastViewed { get; set; }
        public object watches { get; set; }
        public object creator { get; set; }
        public object subtasks { get; set; }
        public string created { get; set; }
        public object reporter { get; set; }
        public object customfield_10000 { get; set; }
        public object aggregateprogress { get; set; }
        public object priority { get; set; }
        public object customfield_10001 { get; set; }
        public object customfield_10002 { get; set; }
        public object labels { get; set; }
        public string environment { get; set; }
        public object timeestimate { get; set; }
        public object aggregatetimeoriginalestimate { get; set; }
        public object versions { get; set; }
        public object duedate { get; set; }
        public object progress { get; set; }
        public Comment2 comment { get; set; }
        public object issuelinks { get; set; }
        public object votes { get; set; }
        public Worklog2 worklog { get; set; }
        public object assignee { get; set; }
        public string updated { get; set; }
        public object status { get; set; }
    }

    public class Names
    {
        public string issuetype { get; set; }
        public string components { get; set; }
        public string timespent { get; set; }
        public string timeoriginalestimate { get; set; }
        public string description { get; set; }
        public string project { get; set; }
        public string fixVersions { get; set; }
        public string aggregatetimespent { get; set; }
        public string resolution { get; set; }
        public string timetracking { get; set; }
        public string customfield_10006 { get; set; }
        public string attachment { get; set; }
        public string aggregatetimeestimate { get; set; }
        public string resolutiondate { get; set; }
        public string workratio { get; set; }
        public string summary { get; set; }
        public string lastViewed { get; set; }
        public string watches { get; set; }
        public string creator { get; set; }
        public string subtasks { get; set; }
        public string created { get; set; }
        public string reporter { get; set; }
        public string customfield_10000 { get; set; }
        public string aggregateprogress { get; set; }
        public string priority { get; set; }
        public string customfield_10001 { get; set; }
        public string customfield_10002 { get; set; }
        public string labels { get; set; }
        public string environment { get; set; }
        public string timeestimate { get; set; }
        public string aggregatetimeoriginalestimate { get; set; }
        public string versions { get; set; }
        public string duedate { get; set; }
        public string progress { get; set; }
        public string comment { get; set; }
        public string issuelinks { get; set; }
        public string votes { get; set; }
        public string worklog { get; set; }
        public string assignee { get; set; }
        public string updated { get; set; }
        public string status { get; set; }
    }

    public class Issue
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
    }

    public class JiraRoot
    {
        public string expand { get; set; }
        public string id { get; set; }
        public string self { get; set; }
        public string key { get; set; }
        public Fields fields { get; set; }
        public RenderedFields renderedFields { get; set; }
        public Names names { get; set; }
    }

    public class IssuesResult
    {
        public string expand { get; set; }
        public int startAt { get; set; }
        public int maxResults { get; set; }
        public int total { get; set; }
        public List<Issue> issues { get; set; }
    }

    public class JiraPostRoot
    {
        public Dictionary<string, object> fields { get; set; }
    }

    public class JiraPostProject
    {
        public string key { get; set; }
    }

    public class JiraPostIssuetype
    {
        public string name { get; set; }
    }
}
