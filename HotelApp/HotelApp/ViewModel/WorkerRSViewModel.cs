using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelApp.Database;
using HotelApp.Reservations;
using HotelApp.RoomService;
using HotelApp.Timetable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    public class WorkerRSViewModel : ViewModelBase
    {
        private ObservableCollection<Reservation> reservationList = new ObservableCollection<Reservation>();
        private Reservation selectedReservation;
        //private DateTime startDate;
        //private DateTime endDate;
        private ICalendar calendarHandler;
        private IReservationUI reservationHandler;
        private IRoomServiceUI roomServiceHandler;
        public ObservableCollection<Reservation> Rezerwacje
        {
            get
            {
                return reservationList;
            }

            set
            {
                reservationList = value;
                RaisePropertyChanged();
            }
        }

        public Reservation SelectedReservation
        {
            get
            {
                return selectedReservation;
            }

            set
            {
                selectedReservation = value;
                RaisePropertyChanged();
            }
        }

        /*public DateTime StartDate
        {
            get
            {
                return startDate;
            }

            set
            {
                startDate = value;
                RaisePropertyChanged();
            }
        }

        public DateTime EndDate
        {
            get
            {
                return endDate;
            }

            set
            {
                endDate = value;
                RaisePropertyChanged();
            }
        }*/
        public WorkerRSViewModel()
        {
            calendarHandler = new Calendar();
            reservationHandler = new ReservationUIService();
            roomServiceHandler = new RoomServiceUIMethods();
            //startDate = DateTime.Now.AddDays(-14);
            //endDate = DateTime.Now.AddMonths(1);
            Refresh = new RelayCommand(RefreshCommand);
            Accept = new RelayCommand(AcceptCommand);
            Cancel = new RelayCommand(CancelCommand);
            RefreshCommand();
        }
        public ICommand Refresh { get; private set; }
        public ICommand Accept { get; private set; }
        public ICommand Cancel { get; private set; }
        private void RefreshCommand()
        {
            reservationList.Clear();
            List<Reservation> temp;
            temp = roomServiceHandler.getAllReservations();
            foreach (Reservation r in temp)
            {
                if (r.Confirmed == false && r.Canceled == false)
                {
                    reservationList.Add(r);
                }
            }
        }
        private void AcceptCommand()
        {
            if(selectedReservation !=null)
            roomServiceHandler.acceptReservation(SelectedReservation);
            RefreshCommand();
        }
        private void CancelCommand()
        {
            if(selectedReservation!=null)
            reservationHandler.cancelReservation(selectedReservation.Id, reservationList.ToList<Reservation>());
            RefreshCommand();
        }
    }
}
