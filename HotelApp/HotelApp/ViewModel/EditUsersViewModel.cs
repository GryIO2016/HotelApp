using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using HotelApp.Database;
using HotelApp.LoginModule;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Text.RegularExpressions;

namespace HotelApp.ViewModel
{
    public class EditUsersViewModel : ViewModelBase
    {
        private ObservableCollection<User> userList = new ObservableCollection<User>();
        private string name, lstName, phone, email, password, pesel;
        private DateTime birtDate;
        private User selectedUser;
        private bool isButtonEnabled = false;
        private ILoginUI loginUI;
        private User oldUser;
        private User newUser;
        int role;
        int id;


        public int Role
        {
            get
            {
                return role;
            }

            set
            {
                role = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public string LstName
        {
            get
            {
                return lstName;
            }

            set
            {
                lstName = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public string Email
        {
            get
            {
                return email;

            }

            set
            {
                email = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public string Pesel
        {
            get
            {
                return pesel;
            }

            set
            {
                pesel = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public DateTime BirtDate
        {
            get
            {
                return birtDate;
            }

            set
            {
                birtDate = value;
                RaisePropertyChanged();
                CheckRegisterButton();
            }
        }

        public ObservableCollection<User> ListaUżytkowników
        {
            get
            {
                return userList;
            }

            set
            {
                userList = value;
                RaisePropertyChanged();

            }
        }

        public User SelectedUser
        {
            get
            {
                return selectedUser;
            }

            set
            {
                selectedUser = value;
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

        public EditUsersViewModel()
        {
            loginUI = new Logger();
            List<User> temp = loginUI.ListUsers();
            temp.ForEach(userList.Add);
            Refresh = new RelayCommand(RefreshCommand);
            SelectUser = new RelayCommand(SelectUserCommand);
            EditUser = new RelayCommand<string>(EditUserCommand);

        }
        public ICommand Refresh { get; private set; }
        public ICommand SelectUser { get; private set; }
        public ICommand EditUser { get; private set; }
        private void RefreshCommand()
        {
            userList.Clear();
            List<User> temp = loginUI.ListUsers();
            temp.ForEach(userList.Add);
        }
        private void SelectUserCommand()
        {
            oldUser = selectedUser;
            Name = selectedUser.Name;
            LstName = selectedUser.LastName;
            Pesel = selectedUser.Pesel;
            Phone = selectedUser.Phone;
            Email = selectedUser.Email;
            BirtDate = selectedUser.BirthDate;
            Role = (int)selectedUser.Role-1;
            id = selectedUser.Id;
        }
        private void EditUserCommand(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Puste pole hasła!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if(!loginUI.EditUser(oldUser, Name, LstName, BirtDate, Phone, Email, password, Pesel, (EnumHelper.Role)(Role+1)))
            {
                MessageBox.Show("Nie udało się zedytować użytkownika!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);

            }
            RefreshCommand();


        }
        private void CheckRegisterButton()
        {
            bool isEnabled = true;
            if (string.IsNullOrWhiteSpace(Name))
                isEnabled = false;
            if (string.IsNullOrWhiteSpace(LstName))
                isEnabled = false;
            if (Phone == null)
                isEnabled = false;
            else
            {
                if (Phone.Length != 9)
                    isEnabled = false;
                Regex regex = new Regex("[0-9]+");
                if (!regex.IsMatch(Phone))
                    isEnabled = false;
            }
            if (Pesel == null)
                isEnabled = false;
            /*else
            {
                Regex regex = new Regex("[0-9]{11}");
                if (!regex.IsMatch(Pesel))
                    isEnabled = false;
                else
                {
                    int[] mnozniki = new int[] { 9, 7, 3, 1, 9, 7, 3, 1, 9, 7 };
                    int sum = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        sum += (Pesel[i] - '0') * mnozniki[i];
                    }
                    if (sum % 10 != Pesel[10] - '0')
                        isEnabled = false;
                }
            }*/

            try
            {
                var mail = new System.Net.Mail.MailAddress(Email);
            }
            catch (Exception)
            {
                isEnabled = false;
            }
            IsRegisterButtonEnabled = isEnabled;
        }
    }
}
