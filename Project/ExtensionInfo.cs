using RemObjects.Hydra;
using SystemWeaver.ExtensionsAPI;

namespace SWExtension.Jira
{
    [Plugin, NonVisualPlugin]
    public class ExtensionInfo : ExtensionInfoBase, IswExtensionInfo
    {
        public string GetAbout()
        {
            return string.Empty;
        }

        public string GetExtensionsAPIVersion()
        {
            return ExtensionsAPI.Version;
        }
    }
}
