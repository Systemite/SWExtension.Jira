using SWExtension.Jira.Common;
using SWExtension.Jira.Models;
using SWExtension.Jira.Mvvm;
using SWExtension.Jira.Views;
using SWExtension.Jira.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using SystemWeaver.ExtensionsAPI;

namespace SWExtension.Jira.ViewModels
{
    public class JiraViewModel : ViewModelBase
    {
        JiraCommands _jiraCommands;

        private IswItem _currentItem;
        public IswItem CurrentItem
        {
            set
            {
                _currentItem = value;

                if (!string.IsNullOrEmpty(JiraLoginInfo.UserName) && !string.IsNullOrEmpty(JiraLoginInfo.Password))
                {
                    UpdateSearch();
                }
            }
        }

        private IswItemViewHost _host;
        public IswItemViewHost Host
        {
            set
            {
                _host = value;
                _jiraCommands.ItemBaseUrl = _host.GetServerUrl();
            }
        }

        private ObservableCollection<JiraIssue> _issueList;
        public ObservableCollection<JiraIssue> IssueList
        {
            get { return _issueList; }
            set { Set(ref _issueList, value); }
        }

        private JiraIssue _selectedIssue;
        public JiraIssue SelectedIssue
        {
            get { return _selectedIssue; }
            set { Set(ref _selectedIssue, value); }
        }

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(Refresh); }
        }

        public ICommand LoginCommand
        {
            get { return new RelayCommand(Login); }
        }

        public ICommand CreateIssueCommand
        {
            get { return new RelayCommand(CreateIssue, CanCreateIssue); }
        }

        public JiraViewModel()
        {
            if (!IsInDesignMode())
            {
                Debug.Assert(JiraItemView.Config != null);

                // This is the only place where we read ItemView.Config
                // ItemView.Config is updated when we edit the configuration in swExplorer. We
                // do not want this to immediately affect a running view. After editing the configuration, you have to switch to 
                // overview and then back to the jira extension for the viewmodel to be recreated with a new JiraCommands
                // with the new configuration. Also SetHost will be called to complete the confgiuration of the JiraCommands
                ExtensionConfig conf = JiraItemView.Config;
                _jiraCommands = new JiraCommands(conf.BaseUrl, conf.MainProject, conf.IssueType, conf.CustomField);
                _jiraCommands.UserName = JiraLoginInfo.UserName;
                _jiraCommands.Password = JiraLoginInfo.Password;
            }
        }

        private void UpdateSearch()
        {
            var issues = _jiraCommands.SearchIssues(_currentItem);
            IssueList = JsonIssuesToJiraIssues(issues);
        }

        public void GotoJiraIssue(JiraIssue issue)
        {
            _jiraCommands.OpenIssue(issue);
        }

        private void Refresh()
        {
            UpdateSearch();
        }

        private void Login()
        {
            var loginDialog = new Login();
            loginDialog.UserNameBox.Text = JiraLoginInfo.UserName;
            loginDialog.PasswordBox.Password = JiraLoginInfo.Password;
            loginDialog.UserNameBox.Focus();

            if (loginDialog.ShowDialogWithProcessOwner() == true)
            {
                JiraLoginInfo.UserName = loginDialog.UserName;
                JiraLoginInfo.Password = loginDialog.Password;

                _jiraCommands.UserName = JiraLoginInfo.UserName;
                _jiraCommands.Password = JiraLoginInfo.Password;

                if (string.IsNullOrEmpty(_jiraCommands.JiraBaseUrl))
                {
                    ShowErrorMessage("Url for Jira server is missing in config");
                    return;
                }

                if (string.IsNullOrEmpty(_jiraCommands.JiraProjectName))
                {
                    ShowErrorMessage("Main project for Jira server is missing in config");
                }

                try
                {
                    UpdateSearch();
                }
                catch (Exception e)
                {
                    ShowErrorMessage(e.Message);
                }
            }
        }

        private void CreateIssue()
        {
            _jiraCommands.CreateIssue(_currentItem);
            UpdateSearch();
        }

        private bool CanCreateIssue()
        {
            if (_jiraCommands == null)
                return false;

            if (string.IsNullOrEmpty(JiraLoginInfo.UserName))
                return false;

            if (string.IsNullOrEmpty(JiraLoginInfo.Password))
                return false;

            if (string.IsNullOrEmpty(_jiraCommands.JiraProjectName))
                return false;

            return true;
        }

        // ObservableCollection is slow, but for this example we use it as a straightforward way to avoid the wpf memory leak.
        private ObservableCollection<JiraIssue> JsonIssuesToJiraIssues(List<Issue> jsonIssues)
        {
            if (jsonIssues == null)
                return new ObservableCollection<JiraIssue>();
            
            return new ObservableCollection<JiraIssue>(jsonIssues.Select(issue => new JiraIssue(issue)));
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
