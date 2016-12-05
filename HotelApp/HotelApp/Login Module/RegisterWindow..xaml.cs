using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Liphsoft.Crypto.Argon2;

namespace LoggingApp
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            DataObject.AddPastingHandler(phoneNumberTextBox, OnPaste);
            firstNameTextBox.MaxLength = 20;
            lastNameTextBox.MaxLength = 20;
            phoneNumberTextBox.MaxLength = 9;
            loginTextBox.MaxLength = 20;
            passwordBox.MaxLength = 20;
        }
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Logging dane = new Logging();
            PasswordHasher hasher = new PasswordHasher();
            try
            {
                if (string.IsNullOrWhiteSpace(firstNameTextBox.Text))
                {
                    MessageBox.Show("Podaj imię");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.FirstName = firstNameTextBox.Text;
                }

                if (string.IsNullOrWhiteSpace(lastNameTextBox.Text))
                {
                    MessageBox.Show("Podaj nazwisko");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.LastName = lastNameTextBox.Text;
                }

                if (phoneNumberTextBox.GetLineLength(0) != 9)
                {
                    MessageBox.Show("Podaj prawidłowy numer telefonu");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.PhoneNumber = Int32.Parse(phoneNumberTextBox.Text);

                }

                if (birthDatePicker.SelectedDate == null)
                {
                    MessageBox.Show("Podaj datę urodzenia");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.BirthDate = birthDatePicker.SelectedDate.Value.ToShortDateString();
                }

                if (loginTextBox.Text.Length < 4)
                {
                    MessageBox.Show("Podaj prawidłowy login. Musi zawierać przynajmniej 4 znaki");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.Login = loginTextBox.Text;
                }

                if (passwordBox.Password.Length < 8)
                {
                    MessageBox.Show("Podaj prawidłowe hasło. Musi zawierać przynajmniej 8 znaków");
                    Exception exc = new Exception();
                    throw exc;
                }
                else
                {
                    dane.Password = hasher.Hash(passwordBox.Password);
                }

                MessageBox.Show("Imię: " + dane.FirstName + "\nNazwisko: " + dane.LastName + "\nNumer telefonu: " + dane.PhoneNumber + "\nData urodzenia: " + dane.BirthDate + "\nLogin: " + dane.Login + "\nHasło: " + dane.Password);
            }
            catch (Exception)
            {
  
            }
        }

        private void phoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
                e.Handled = true;
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }

        private void OnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }
    }
}


