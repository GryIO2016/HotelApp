using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HotelApp.Database;
using HotelApp.LoginModule;
using HotelApp.UI;
using System.Windows;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string loginText;

        private ILoginUI loginUI;
        public ICommand Login { get; private set; }
        public ICommand Register { get; private set; }
        public string LoginText
        {
            get
            {
                return loginText;
            }
            set
            {
                loginText = value;
                RaisePropertyChanged();
            }
        }

        public LoginViewModel()
        {
            loginUI = new Logger();
            Login = new RelayCommand<string>(LoginCommand);
            Register = new RelayCommand(RegisterCommand);
        }

        private void RegisterCommand()
        {
            RegisterView registerWindow = new RegisterView();
            registerWindow.ShowDialog();
        }

        private void LoginCommand(string password)
        {
            User tempUser = null;
            tempUser = loginUI.LogIn(LoginText, password);
            if (tempUser == null)
                MessageBox.Show("Nieprawidłowy email/hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessengerInstance.Send<UserMessage>(new UserMessage() { NewUser = tempUser });
        }
    }
}
