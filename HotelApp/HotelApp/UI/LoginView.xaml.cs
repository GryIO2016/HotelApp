using HotelApp.ViewModel;
using System.Windows.Controls;

namespace HotelApp.UI
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            (DataContext as LoginViewModel).Login.Execute(passwordBox.Password);
        }
    }
}
