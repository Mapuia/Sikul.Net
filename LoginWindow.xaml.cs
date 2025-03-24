using System.Windows;

namespace Sikul
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordTextBox.Password;

            // Simple password check, replace with secure authentication
            if (username == "admin" && password == "password")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }

        private void ViewReportsButton_Click(object sender, RoutedEventArgs e)
        {
            // Implement logic to view previous reports without login
            MessageBox.Show("Viewing previous reports...");
        }
    }
}