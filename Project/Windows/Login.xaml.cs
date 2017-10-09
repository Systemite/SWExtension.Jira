using System.Windows;
using System.Windows.Controls;

namespace SWExtension.Jira.Windows
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            UserName = UserNameBox.Text;
            Password = PasswordBox.Password;

            DialogResult = true;
            Close();
        }
    }
}
