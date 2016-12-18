using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using HotelApp.Database;
using HotelApp.UI;
using System.Windows;
using System.Windows.Input;
using System;
using LoggingApp;

namespace HotelApp.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string loginText;
        private string passwordText;

        //ILoggingUI loginUI;
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
            //MessageBox.Show("Brak implementacji ILoggingUI!", "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            DBManagment testObject = new DBManagment();
            User testUser = new User();
            testUser = testObject.findUser("kowalski@a.pl");
            //MessageBox.Show("Login", "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            //User tempUser = loginUI.Login(LoginText, PasswordText);
            //if (tempUser == null)
            //    MessageBox.Show("Niepoprawna nazwa użytkownika/hasło!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            //MessengerInstance.Send<UserMessage>(new UserMessage() { NewUser = tempUser });
        }
    }
}
