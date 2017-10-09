using System;
using System.Windows;

namespace SWExtension.Jira.Common
{
    public static class DialogExtensions
    {
        /// <summary>
        /// Opens the provided window with the current process main window as Owner window.
        /// </summary>
        public static bool? ShowDialogWithProcessOwner(this Window window)
        {
            if (window == null)
                throw new ArgumentNullException("window");

            var mainWindowHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            var interopHelper = new System.Windows.Interop.WindowInteropHelper(window)
            {
                Owner = mainWindowHandle
            };

            return window.ShowDialog();
        }
    }
}
