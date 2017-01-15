﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelApp.Database;

namespace HotelApp.Timetable
{
    public class Calendar : ICalendar, IReservationProcedures
    {
        private List<Reservation> reservations = new List<Reservation>();
        private DBManagment dataBase = new DBManagment();

        public void addReservation(Reservation reservation)
        {
            dataBase.addReservation(reservation);
            reservations.Add(reservation);
        }

        public void editReservation(Reservation oldReservation, Reservation newReservation)
        {
            dataBase.editReservation(oldReservation, newReservation);
            /*if (reservations.Contains(oldReservation))
            {
                reservations[reservations.IndexOf(oldReservation)] = newReservation;
            }
            else
            {
                throw new ReservationNotFoundException();
            }*/
        }

        public List<Room> getFreeRooms(DateTime startDate, DateTime endTime)
        {
            return dataBase.getFreeRooms(startDate, endTime);
        }

        public List<Reservation> getReservations(DateTime startDate, DateTime endDate)
        {
            DBManagment dbm = new DBManagment();
            List<Reservation> temp = new List<Reservation>();
            temp = dbm.getAllReservations();

            foreach (Reservation res in reservations)
            {
                if (res.CheckOutDate > startDate && res.CheckInDate < endDate)
                {
                    temp.Add(res);
                }
            }
            return temp;
        }

        public List<Reservation> getAllReservations()
        {
            DBManagment dbm = new DBManagment();
            List<Reservation> temp = new List<Reservation>();
            temp = dbm.getAllReservations();

            return temp;
        }

        public List<Reservation> getUserReservations(User user)
        {
            List<Reservation> temp = new List<Reservation>();
            foreach (Reservation res in reservations)
            {
                if (res.User == user)
                {
                    temp.Add(res);
                }
            }
            return temp;
        }
    }
}
