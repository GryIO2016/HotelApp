using HotelApp.ViewModel;
using System.Windows;

namespace HotelApp.UI
{
    /// <summary>
    /// Interaction logic for RegisterView.xaml
    /// </summary>
    public partial class RegisterView : Window
    {
        public RegisterView()
        {
            InitializeComponent();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as RegisterViewModel)?.RegisterUser.Execute(passwordBox.Password);
        }
    }
}
