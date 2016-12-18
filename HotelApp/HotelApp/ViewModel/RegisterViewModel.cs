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
    public class RegisterViewModel : ViewModelBase
    {
        private string firstNameText;
        private string lastNameText;
        private string phoneNumberText;
        private string birthDateText;
        private string loginText;
        private string passwordText;

        //ILoggingUI loginUI;
        public ICommand RegisterUser { get; private set; }
 
        public RegisterViewModel()
        {
            //loginUI = new LoginUI();
            RegisterUser = new RelayCommand(RegisterCommand);
            
        }

        private void RegisterCommand()
        {
            MessageBox.Show("Brak implementacji ILoggingUI!", "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
