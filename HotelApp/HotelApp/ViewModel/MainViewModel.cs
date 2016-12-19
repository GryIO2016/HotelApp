using GalaSoft.MvvmLight;
using HotelApp.Database;
using HotelApp.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
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

        public ObservableCollection<UIButton> UIButtons { get; set; }
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
                ActiveUser.Instance.CurrentUser = value;
                RaisePropertyChanged();
            }
        }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            MessengerInstance.Register<UserMessage>(this, ChangeCurrentUser);
            MessengerInstance.Register<NavigateMessage>(this, ChangeCurrentView);
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
                UIButtons = new ObservableCollection<UIButton>();
                RaisePropertyChanged("UIButtons");
            }
            else
            {
                //Tu zmieniæ dostêpne zak³adki, czyli...
                //sprawdziæ uprawnienia u¿ytkownika
                switch (CurrentUser.Role)
                {
                    case EnumHelper.Role.Admin: //Je¿eli admin
                        views = new List<UserControl> { new TimetablesView(), new ReservationsView(), new StatisticsView(), new RoomServiceView() };
                        break;
                    case EnumHelper.Role.Client: //Je¿eli klient
                        //views = {...}
                        break;
                    case EnumHelper.Role.Employee: //Je¿eli pracownik
                        //views = {...}
                        break;
                }
                UIButtons = new ObservableCollection<UIButton>();
                for (int i = 0; i < views.Count; i++)
                {
                    UIButtons.Add(new NavigationButton { ButtonName = views[i].Tag.ToString(), ViewNumber = i });
                }
                UIButtons.Add(new LogoutButton());
                RaisePropertyChanged("UIButtons");
            }
            CurrentView = views[0];
        }
        private void ChangeCurrentView(NavigateMessage msg)
        {
            if (msg.ViewNumber > views.Count - 1)
            {
                string message = string.Format("B³¹d w MainViewModel:\n-liczba widoków: {0},\n-podana liczba: {1}", views.Count, msg.ViewNumber);
                MessageBox.Show(message);
                return;
            }
            CurrentView = views[msg.ViewNumber];
        }
    }
}