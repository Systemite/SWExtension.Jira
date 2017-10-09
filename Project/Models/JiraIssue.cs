using System.ComponentModel;
namespace SWExtension.Jira.Models
{
    public class JiraIssue : INotifyPropertyChanged
    {
        // This is not used, it is only for fixing the memory leak in wpf, since the properties of JiraIssue are bound to from the wpf view.
        public event PropertyChangedEventHandler PropertyChanged;
        
        public string Key { get; set; }
        public string Project { get; set; }
        public string Summary { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public string Status { get; set; }
        public string IssueType { get; set; }
        public string Priority { get; set; }

        public JiraIssue(Issue issue)
        {
            Key = issue.key;

            if (issue.fields != null)
            {
                Assignee = issue.fields.assignee != null ? issue.fields.assignee.name : string.Empty;
                Project = issue.fields.project != null ? issue.fields.project.name : string.Empty;
                Summary = issue.fields.summary != null ? issue.fields.summary : string.Empty;
                Reporter = issue.fields.reporter != null ? issue.fields.reporter.name : string.Empty;
                IssueType = issue.fields.issuetype != null ? issue.fields.issuetype.name : string.Empty;
                Status = issue.fields.status != null ? issue.fields.status.name : string.Empty;
                Priority = issue.fields.priority != null ? issue.fields.priority.name : string.Empty;
            }
        }
    }
}
