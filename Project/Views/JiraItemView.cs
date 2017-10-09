using RemObjects.Hydra;
using SWExtension.Jira.Models;
using System;
using System.ComponentModel;
using SystemWeaver.ExtensionsAPI;

namespace SWExtension.Jira.Views
{
    [Plugin, NonVisualPlugin]
    public partial class JiraItemView : NonVisualPlugin, IswItemView
    {
        private IswBroker _broker;

        // This is the fixed Guid used by the swExplorer.exe, you need to use this if you want to get
        // the settings from "Configure the explorer"
        private static readonly Guid _swExplorerAppConfigGuid = new Guid("{66E59E81-2EA6-478E-B650-2A222A559B98}");
        private static readonly Guid _appConfigJiraItemViewGuid = new Guid("{7168626f-0635-4bdc-be8b-4c9fbec35be2}");

        public JiraItemView()
        {
            InitializeComponent();
        }

        public JiraItemView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Initialize(IswBroker ABroker)
        {
            // This method is called once when the swExplorer GUI is updated at first login,
            // and when the settings are edited in "Configure the explorer".
            _broker = ABroker;
            Config = GetExtensionConfig();
        }

        public static ExtensionConfig Config
        {
            get;
            private set;
        }

        public string GetCaption()
        {
            return "Jira";
        }

        public string GetGroup()
        {
            return "Extensions";
        }

        public string GetName()
        {
            return typeof(JiraItemViewContent).FullName;
        }

        public int GetImageIndex()
        {
            return -1;
        }

        public string GetPluginContentName()
        {
            return typeof(JiraItemViewContent).FullName;
        }

        public bool SupportsItem(IswItem AItem)
        {
            // If the config is not correct we always return false.
            // This will ensure that the actual view and view-model are not created with null Config.
            if (Config == null)
            {
                return false;
            }

            return AItem.IsSID(Config.ItemType);
        }

        public Guid GetGUID()
        {
            return _appConfigJiraItemViewGuid;
        }

        public string GetConfigXMLExample()
        {
            return @"<JiraConfiguration>
                         <BaseUrl>http://jiraserver:8085</BaseUrl>
                         <MainProject>ESP</MainProject>
                         <CustomField>customfield_10200</CustomField>
                         <IssueType>Bug</IssueType>
                         <ItemType>RQ</ItemType>
                     </JiraConfiguration>";
        }

        public void ValidateConfigXML(string AXML)
        {
            // This method will raise an exception which is nicely propagated to "Configure the explorer" if something is wrong.
            new ExtensionConfig(AXML);
        }

        public ExtensionConfig GetExtensionConfig()
        {
            try
            {
                IswApplicationConfig config = _broker.GetApplicationConfig(_swExplorerAppConfigGuid);
                string xml = config.ConfigXML(_appConfigJiraItemViewGuid);
                return new ExtensionConfig(xml);
            }
            catch
            {
                return null;
            }
        }
    }
}
