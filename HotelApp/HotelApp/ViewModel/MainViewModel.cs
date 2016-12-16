using GalaSoft.MvvmLight;
using HotelApp.Database;
using HotelApp.UI;
using System.Collections.Generic;
using System.Windows.Controls;

namespace HotelApp.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private User currentUser;
        private List<UserControl> views;
        private UserControl currentView;

        public UserControl CurrentView
        {
            get
            {
                return currentView;
            }
            set
            {
                currentView = value;
                RaisePropertyChanged();
            }
        }

        public User CurrentUser
        {
            get
            {
                return currentUser;
            }
            set
            {
                currentUser = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            MessengerInstance.Register<UserMessage>(this, ChangeCurrentUser);
            views = new List<UserControl>() { new LoginView() };
            CurrentView = views[0];
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        private void ChangeCurrentUser(UserMessage msg)
        {
            CurrentUser = msg.NewUser;
            if (CurrentUser == null)
            {
                views = new List<UserControl>() { new LoginView() };
            }
            else
            {
                //Tu zmieniæ dostêpne zak³adki, czyli...
                //sprawdziæ uprawnienia u¿ytkownika
                switch (CurrentUser.Role)
                {
                    case EnumHelper.Role.Admin: //Je¿eli admin
                        //views = {...}
                        break;
                    case EnumHelper.Role.Client: //Je¿eli klient
                        //views = {...}
                        break;
                    case EnumHelper.Role.Employee: //Je¿eli pracownik
                        //views = {...}
                        break;
                }
            }
            CurrentView = views[0];
        }
    }
}