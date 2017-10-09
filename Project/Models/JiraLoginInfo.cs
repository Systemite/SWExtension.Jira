namespace SWExtension.Jira.Models
{
    // This is used to store the login-name and password to Jira.
    // Has to be static to survive that the item-view is closed and opened again.
    internal static class JiraLoginInfo
    {
        public static string UserName { get; set; }
        public static string Password { get; set; }
    }
}
