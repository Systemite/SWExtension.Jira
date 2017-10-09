using RemObjects.Hydra;
using RemObjects.Hydra.CrossPlatform;
using SWExtension.Jira.ViewModels;
using SystemWeaver.ExtensionsAPI;

namespace SWExtension.Jira.Views
{
    /// <summary>
    /// Interaction logic for ItemViewContent.xaml
    /// </summary>
    [Plugin, VisualPlugin, NeedsManagedWrapper(typeof(WPFPluginContentWrapper))]
    public partial class JiraItemViewContent : RemObjects.Hydra.WPF.VisualPlugin, IswItemViewContent
    {
        private IswItemViewHost _host;
        private SWEventManager _eventManager;
        private IswDialogs _dialogs;
        private JiraViewModel _jiraViewModel;

        public JiraItemViewContent()
        {
            InitializeComponent();
            _eventManager = new SWEventManager();

            _jiraViewModel = JiraControl.DataContext as JiraViewModel;
        }

        public void SetHost(IswItemViewHost host)
        {
            _host = host;
            _host.SetEvent(_eventManager);
            _dialogs = _host.GetDialogs();
            _jiraViewModel.Host = _host;
        }

        public void SetCurrentItem(IswItem AItem)
        {
            _jiraViewModel.CurrentItem = AItem;
        }
    }
}
