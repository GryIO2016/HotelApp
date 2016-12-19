using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelApp.Reservations;
using HotelApp.Database;

namespace HotelApp.ViewModel
{
    public class ReservationViewModel : ViewModelBase
    {
        User currentUser;
        private DateTime checkinDate;
        private DateTime checkoutDate;
        private bool smokingAvailable;
        private bool petsAvailable;
        private int bedType;
        private double minPrice = 10.00;
        private double maxPrice = 1000.00;
        List<Room> rooms = new List<Room> { };
        IReservationUI ReservationService;
        public int BedType
        {
            get
            {
                return bedType;
            }
            set
            {
                bedType = value;
                RaisePropertyChanged();
            }
        }
        public double MinPrice
        {
            get
            {
                return minPrice;
            }
            set
            {
                minPrice = value;
                RaisePropertyChanged();
            }
        }
        public double MaxPrice
        {
            get
            {
                return maxPrice;
            }
            set
            {
                maxPrice = value;
                RaisePropertyChanged();
            }
        }
        public DateTime CheckinDate
        {
            get
            {
                return checkinDate;
            }
            set
            {
                checkinDate = value;
                RaisePropertyChanged();
            }
        }
        public DateTime CheckoutDate
        {
            get
            {
                return checkoutDate;
            }
            set
            {
                checkoutDate = value;
                RaisePropertyChanged();
            }
        }
        public bool PetsAvailable
        {
            get
            {
                return petsAvailable;
            }
            set
            {
                petsAvailable = value;
                RaisePropertyChanged();
            }
        }
        public bool SmokingAvailable
        {
            get
            {
                return smokingAvailable;
            }
            set
            {
                smokingAvailable = value;
                RaisePropertyChanged();
            }
        }
        public ICommand RoomList { get; private set; }
        public ReservationViewModel()
        {
            ReservationService = new ReservationUIService();
            RoomList = new RelayCommand(RoomListCommand);
        }
        private void RoomListCommand()
        {
            rooms = ReservationService.getRooms((EnumHelper.Status)4, rooms);
            rooms = ReservationService.getRooms(minPrice, maxPrice, rooms);
            rooms = ReservationService.getRooms((EnumHelper.BedType)bedType, rooms);
            rooms = ReservationService.getRoomsBySmoking(smokingAvailable, rooms);
            rooms = ReservationService.getRoomsByPets(petsAvailable, rooms);
            ReservationService.createReservation(currentUser, checkinDate, checkoutDate, rooms);
            
        }
    }
}
