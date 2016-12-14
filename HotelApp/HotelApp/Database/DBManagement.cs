using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Database
{
    public class DBManagment : ICalendarData, ILogging
    {
        // ICalendarData

        public void addReservation(Reservation reservation)
        {
            using (var Conn = new IO2017Entities())
            {
                reservations r = new reservations();
                r.check_in = reservation.CheckInDate;
                r.check_out = reservation.CheckOutDate;
                r.confirmed = reservation.Confirmed;
                r.paid = reservation.Paid;
                r.user_id = reservation.User.Id;
                r.canceled = reservation.Canceled;

                ICollection<rooms> rooms = new List<rooms>();
                foreach (Room room in reservation.Rooms)
                {
                    var rm = Conn.rooms
                        .Where(b => b.room_id == room.Id)
                        .FirstOrDefault();
                    rooms.Add(rm);
                }

                r.rooms = rooms;

                Conn.reservations.Add(r);
                Conn.SaveChanges();
            }
        }

        public List<Room> getFreeRooms(DateTime startDate, DateTime endTime)
        {
            throw new NotImplementedException();
        }

        public void editReservation(Reservation oldReservation, Reservation newReservation)
        {
            using (var Conn = new IO2017Entities())
            {
                reservations reservation = Conn.reservations.Find(oldReservation.Id);
                if (reservation != null)
                {
                    reservation.check_in = newReservation.CheckInDate;
                    reservation.check_out = newReservation.CheckOutDate;
                    reservation.confirmed = newReservation.Confirmed;
                    reservation.paid = newReservation.Paid;
                    reservation.user_id = newReservation.User.Id;
                    reservation.canceled = newReservation.Canceled;

                    reservation.rooms.Clear();

                    ICollection<rooms> rooms = new List<rooms>();
                    foreach (Room room in newReservation.Rooms)
                    {
                        var rm = Conn.rooms
                            .Where(b => b.room_id == room.Id)
                            .FirstOrDefault();
                        rooms.Add(rm);
                    }

                    reservation.rooms = rooms;
                    Conn.SaveChanges();
                }
            }
        }

        public List<Reservation> getReservations(DateTime startDate, DateTime endDate)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (var Conn = new IO2017Entities())
            {
                var find = Conn.reservations
                    .Where(b => b.check_in >= startDate & b.check_out <= endDate);

                foreach (var reservation in find)
                {
                    List<Room> rooms = new List<Room>();
                    foreach (var r in reservation.rooms)
                    {
                        Room room = new Room(r.room_id, r.number, (double)r.price, r.smoking, r.pets, (EnumHelper.BedType)r.bed_type, (EnumHelper.Status)r.room_status);
                        rooms.Add(room);
                    }

                    var u = Conn.users
                        .Where(b => b.user_id == reservation.user_id)
                        .FirstOrDefault();

                    User user = new User(u.user_id, u.first_name, u.last_name, (DateTime)u.birth_date, u.phone_number, u.email, u.password, u.pesel, (EnumHelper.Role)u.role);

                    reservations.Add(new Reservation(reservation.reservation_id, user, reservation.check_in, reservation.check_out, reservation.confirmed, reservation.paid ,rooms, reservation.canceled));
                }
            }

            return reservations;
        }

        public List<Reservation> getUserReservations(User user)
        {
            List<Reservation> reservations = new List<Reservation>();

            using (var Conn = new IO2017Entities())
            {
                var find = Conn.reservations
                    .Where(b => b.user_id == user.Id);

                foreach (var reservation in find)
                {
                    List<Room> rooms = new List<Room>();
                    foreach (var r in reservation.rooms)
                    {
                        Room room = new Room(r.room_id, r.number, (double)r.price, r.smoking, r.pets, (EnumHelper.BedType)r.bed_type, (EnumHelper.Status)r.room_status);
                        rooms.Add(room);
                    }
                    reservations.Add(new Reservation(reservation.reservation_id, user, reservation.check_in, reservation.check_out, reservation.confirmed, reservation.paid, rooms, reservation.canceled));
                }
            }

            return reservations;
        }


        // ILogging

        public void addUser(User user)
        {
            using (var Conn = new IO2017Entities())
            {
                users u = new users();
                u.first_name = user.Name;
                u.last_name = user.LastName;
                u.birth_date = user.BirthDate;
                u.phone_number = user.Phone;
                u.email = user.Email;
                u.password = user.Password;
                u.pesel = user.Pesel;
                u.role = (int)user.Role;
                Conn.users.Add(u);
                Conn.SaveChanges();
            }
        }

        public void editUser(User oldUser, User newUser)
        {
            using (var Conn = new IO2017Entities())
            {
                users u = Conn.users.Find(oldUser.Id);
                if (u != null)
                {
                    u.first_name = newUser.Name;
                    u.last_name = newUser.LastName;
                    u.birth_date = newUser.BirthDate;
                    u.phone_number = newUser.Phone;
                    u.email = newUser.Email;
                    u.password = newUser.Password;
                    u.pesel = newUser.Pesel;
                    u.role = (int)newUser.Role;

                    Conn.SaveChanges();
                }
            }
        }

        public User findUser(string email)
        {
            User user = new User();

            using (var Conn = new IO2017Entities())
            {
                var u = Conn.users
                .Where(b => b.email == email)
                .FirstOrDefault();

                user.Id = u.user_id;
                user.Name = u.first_name;
                user.LastName = u.last_name;
                user.BirthDate = (DateTime)u.birth_date;
                user.Phone = u.phone_number;
                user.Email = u.email;
                user.Password = u.password;
                user.Pesel = u.pesel;
                user.Role = (EnumHelper.Role)u.role;
            }
            return user;

        }

        public User findUser(string email, string password)
        {
            User user = new User();

            using (var Conn = new IO2017Entities())
            {
                var u = Conn.users
                .Where(b => b.email == email && b.password == password)
                .FirstOrDefault();

                user.Name = u.first_name;
                user.LastName = u.last_name;
                user.BirthDate = (DateTime)u.birth_date;
                user.Phone = u.phone_number;
                user.Email = u.email;
                user.Password = u.password;
                user.Pesel = u.pesel;
                user.Role = (EnumHelper.Role)u.role;
            }

            return user;
        }


        // 

        public Room getRoom(int id)
        {
            Room room = new Room();

            using (var Conn = new IO2017Entities())
            {
                var r = Conn.rooms
                .Where(b => b.room_id == id)
                .FirstOrDefault();

                room.Id = r.room_id;
                room.Number = r.number;
                room.Price = (double)r.price;
                room.Smoking = r.smoking;
                room.Pets = r.pets;
                room.BedType = (EnumHelper.BedType)r.bed_type;
                room.RoomStatus = (EnumHelper.Status)r.room_status;
            }
            return room;
        }
    }
}
