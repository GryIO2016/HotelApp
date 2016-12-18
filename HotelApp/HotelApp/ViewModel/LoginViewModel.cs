using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HotelApp.Database;
using HotelApp.UI;
using System.Windows;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string loginText;
        private string passwordText;

        //ILoginUI loginUI;
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
        public string PasswordText
        {
            get
            {
                return passwordText;
            }
            set
            {
                passwordText = value;
                RaisePropertyChanged();
            }
        }

        public LoginViewModel()
        {
            //loginUI = new LoginUI();
            Login = new RelayCommand(LoginCommand);
            Register = new RelayCommand(RegisterCommand);
        }

        private void RegisterCommand()
        {
            RegisterView registerWindow = new RegisterView();
            registerWindow.ShowDialog();
        }

        private void LoginCommand()
        {
            MessageBox.Show("Brak implementacji ILoginUI!", "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            User tempUser = new User { Role = EnumHelper.Role.Admin };
            //tempUser = loginUI.Login(LoginText, PasswordText);
            //if (tempUser == null)
            //    MessageBox.Show("Niepoprawna nazwa użytkownika/hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            MessengerInstance.Send<UserMessage>(new UserMessage() { NewUser = tempUser });
        }
    }
}
