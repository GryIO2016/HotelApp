using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System.Windows;
using System.Windows.Input;
using System;
using System.Text.RegularExpressions;
using HotelApp.LoginModule;
using HotelApp.Database;

namespace HotelApp.ViewModel
{
    public class RegisterViewModel : ViewModelBase
    {
        private ILoginUI loginUI;
        private bool isButtonEnabled = false;
        private string firstNameText;
        private string lastNameText;
        private string phoneNumberText;
        private DateTime birthDate = DateTime.Now;
        private string emailText;
        private string peselText;
        private int role;
        public string FirstNameText
        {
            get
            {
                return firstNameText;
            }
            set
            {
                firstNameText = value;
                CheckRegisterButton();
                RaisePropertyChanged();
            }
        }

        public string LastNameText
        {
            get
            {
                return lastNameText;
            }
            set
            {
                lastNameText = value;
                CheckRegisterButton();
                RaisePropertyChanged();
            }
        }
        public string PhoneNumberText
        {
            get
            {
                return phoneNumberText;
            }
            set
            {
                phoneNumberText = value;
                CheckRegisterButton();
                RaisePropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
                CheckRegisterButton();
                RaisePropertyChanged();
            }
        }
        public string EmailText
        {
            get
            {
                return emailText;
            }
            set
            {
                emailText = value;
                CheckRegisterButton();
                RaisePropertyChanged();
            }
        }
        public bool IsRegisterButtonEnabled
        {
            get { return isButtonEnabled; }
            set
            {
                isButtonEnabled = value;
                RaisePropertyChanged();
            }
        }
        public int Role
        {
            get { return role; }
            set
            {
                role = value;
                RaisePropertyChanged();
            }
        }
        public string PESELText
        {
            get { return peselText; }
            set
            {
                peselText = value;
                RaisePropertyChanged();
            }
        }
        public ICommand RegisterUser { get; private set; }

        public RegisterViewModel()
        {
            loginUI = new Logger();
            RegisterUser = new RelayCommand<string>(RegisterCommand);
        }

        private void RegisterCommand(string password)
        {
            //MessageBox.Show("Brak implementacji ILoginUI! ", "Błąd krytyczny", MessageBoxButton.OK, MessageBoxImage.Error);
            //TODO: Sprawdzić hasło.
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Puste pole hasła!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!loginUI.RegisterUser(FirstNameText, LastNameText, BirthDate, PhoneNumberText, EmailText, password, PESELText, (EnumHelper.Role)Role+2))
            {
                MessageBox.Show("Konto już istnieje!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void CheckRegisterButton()
        {
            bool isEnabled = true;
            if (string.IsNullOrWhiteSpace(FirstNameText))
                isEnabled = false;
            if (string.IsNullOrWhiteSpace(LastNameText))
                isEnabled = false;
            if (PhoneNumberText == null)
                isEnabled = false;
            else
            {
                if (PhoneNumberText.Length != 9)
                    isEnabled = false;
                Regex regex = new Regex("[0-9]+");
                if (!regex.IsMatch(PhoneNumberText))
                    isEnabled = false;
            }
            if (PESELText == null)
                isEnabled = false;
            else
            {
                Regex regex = new Regex("[0-9]{11}");
                if (!regex.IsMatch(PESELText))
                    isEnabled = false;
                else
                {
                    int[] mnozniki = new int[] { 9, 7, 3, 1, 9, 7, 3, 1, 9, 7 };
                    int sum = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        sum += (PESELText[i] - '0') * mnozniki[i];
                    }
                    if (sum % 10 != PESELText[10] - '0')
                        isEnabled = false;
                }
            }

            try
            {
                var mail = new System.Net.Mail.MailAddress(EmailText);
            }
            catch (Exception)
            {
                isEnabled = false;
            }
            IsRegisterButtonEnabled = isEnabled;
        }
    }
}
