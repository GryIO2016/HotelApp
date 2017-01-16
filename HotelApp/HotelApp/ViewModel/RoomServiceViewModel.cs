using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HotelApp.Database;
using HotelApp.RoomService;
using HotelApp.Timetable;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace HotelApp.ViewModel
{
    public class RoomServiceViewModel : ViewModelBase
    {
        int number;
        Room oldRoom;
        bool smoking;
        bool pets;
        int bedType;
        int status;
        double price;
        ObservableCollection<Room> roomList = new ObservableCollection<Room>();
        Room selectedRoom;
        ICalendar calendarHandler = new Calendar();
        IRoomServiceUI roomServiceHendler;
        DBManagment dbConnect = new DBManagment();
        int id;
        public bool Smoking
        {
            get
            {
                return smoking;
            }

            set
            {
                smoking = value;
                RaisePropertyChanged();
            }
        }

        public bool Pets
        {
            get
            {
                return pets;
            }

            set
            {
                pets = value;
                RaisePropertyChanged();
            }
        }

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

        public int Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
                RaisePropertyChanged();
            }
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Room> RoomList
        {
            get
            {
                return roomList;
            }

            set
            {
                roomList = value;
                RaisePropertyChanged();
            }
        }

        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
                RaisePropertyChanged();
            }
        }
        public Room SelectedRoom
        {
            get
            {
                return selectedRoom;
            }

            set
            {
                selectedRoom = value;
                RaisePropertyChanged();
            }
        }

        public RoomServiceViewModel()
        {
            RefreshCommand();
            roomServiceHendler = new RoomServiceUIMethods();
            Refresh = new RelayCommand(RefreshCommand);
            SelectRoom = new RelayCommand(SelectRoomCommand);
            EditRoom = new RelayCommand(AcceptCommand);
        }
        public ICommand Refresh { get; private set; }
        public ICommand SelectRoom { get; private set; }
        public ICommand EditRoom { get; private set; }


        private void RefreshCommand()
        {
            roomList.Clear();
            dbConnect.getAllRooms().ForEach(roomList.Add);

        }
        private void SelectRoomCommand()
        {
            oldRoom = selectedRoom;
            Number = selectedRoom.Number;
            Price = selectedRoom.Price;
            Smoking = selectedRoom.Smoking;
            Pets = selectedRoom.Pets;
            BedType = (int)selectedRoom.BedType - 1;
            Status = (int)selectedRoom.RoomStatus - 1;
            id = selectedRoom.Id;
            RefreshCommand();
        }
        private void AcceptCommand()
        {
            Room newRoom = new Room(id, Number, Price, Smoking, Pets, (EnumHelper.BedType)BedType + 1, (EnumHelper.Status)Status + 1);
            roomServiceHendler.editRoom(oldRoom, newRoom);
            RefreshCommand();
        }



    }


}
