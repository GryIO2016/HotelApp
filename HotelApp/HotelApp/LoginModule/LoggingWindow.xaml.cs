using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Liphsoft.Crypto.Argon2;

namespace LoggingApp
{
    /// <summary>
    /// Interaction logic for LoggingWindow.xaml
    /// </summary>
    public partial class LoggingWindow : Window
    {
        public LoggingWindow()
        {
            InitializeComponent();
            loginTextBox.MaxLength = 20;
            passwordBox.MaxLength = 20;
        }

        private void loginTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Logging dane = new Logging();
            var hasher = new PasswordHasher();
            try
            {
                if (string.IsNullOrWhiteSpace(loginTextBox.Text))
                {
                    MessageBox.Show("Podaj login");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.Login = loginTextBox.Text;
                }

                if (string.IsNullOrWhiteSpace(passwordBox.Password))
                {
                    MessageBox.Show("Podaj hasło");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.Password = hasher.Hash(passwordBox.Password);
                }

                MessageBox.Show("Login: " + dane.Login + "\nHasło: " + dane.Password);
            }
            catch (Exception)
            {

            }
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
        }
    }
}
