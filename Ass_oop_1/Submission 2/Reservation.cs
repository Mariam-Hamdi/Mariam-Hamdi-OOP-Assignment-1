using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Submission_2
{
    internal class Reservation
    {
        public string ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public Room Room { get; }
        public string Status { get; private set; } 

        public Reservation(string reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            if (checkOutDate <= CheckInDate)
                throw new ArgumentException("Check-out date must be strictly after check-in date");
            if (room.IsUnderMaintenance)
                throw new ArgumentException("Cannot create a reservation for a room that is currently under maintenance");
            ReservationId = reservationId;
            CheckInDate   = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Status ="Pending";
        }
      public void ConfirmReservation()
        {
            if (Status != "Pending")
                throw new InvalidOperationException("Reservation can only be confirmed if it is currently Pending");
             Status = "Confirmed";
        }
        public void CheckInReservation()
        {
            if (Status != "Confirmed")
                throw new InvalidOperationException("A reservation cannot be checked in unless it is currently Confirmed");
            Status = "CheckedIn";
        }
        public void CheckOutReservation()
        {
            if (Status != "CheckedIn")
                throw new InvalidOperationException("A reservation cannot be checked out unless the guest is currently CheckedIn");
             Status = "CheckedOut";
        }
        public void CancelReservation()
        {
            if (Status != "Pending" && Status != "Confirmed")
                throw new InvalidOperationException("Reservation can only be cancelled if it is Pending or Confirmed");
                Status = "Cancelled";
        }
        public decimal CalculateTotalCost()
        {
            int nights= (int)(CheckOutDate - CheckInDate).TotalDays;
            return  Room.NightlyRate * nights;
        }




    }
}
