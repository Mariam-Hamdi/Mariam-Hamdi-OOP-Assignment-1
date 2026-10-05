using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
a
namespace Submission_2
{
    internal class Guest
    {
        public string GuestId { get; }
        public string FullName { get; }
        public string PhoneNumber { get; }
        private readonly List <Reservation> _reservations =new List<Reservation>();
        public IReadOnlyList <Reservation> Reservations => _reservations.AsReadOnly();
        public Guest(string guestId, string fullName, string phoneNumber)
        {
            if(string.IsNullOrEmpty(fullName))
                throw new ArgumentException("Guest full name must not be null or empty.");
           if(string.IsNullOrEmpty(phoneNumber))
                throw new ArgumentException("Guest phone number must not be null or empty.");
           
            GuestId = guestId;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
        public void AddReservaion(Reservation res)
        {
            if (res == null)
                throw new ArgumentNullException(nameof(res));
            _reservations.Add(res);
        }
       
    }
}
