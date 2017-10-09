using SWExtension.Jira.Models;
using SWExtension.Jira.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace SWExtension.Jira.Views
{
    /// <summary>
    /// Interaction logic for JiraControl.xaml
    /// </summary>
    public partial class JiraControl : UserControl
    {
        public JiraControl()
        {
            InitializeComponent();
        }

        private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = sender as DataGridRow;
            if (row == null)
                return;

            var issue = row.Item as JiraIssue;
            if (issue == null)
                return;

            if (e.ChangedButton == MouseButton.Left)
                ((JiraViewModel)DataContext).GotoJiraIssue(issue);
        }
    }
}
