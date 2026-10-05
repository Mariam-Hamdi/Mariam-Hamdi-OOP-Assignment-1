namespace Submission_2
{
    internal class Room
    {
        public string RoomNumber { get; }
        public string RoomType { get; }
        public decimal NightlyRate { get; private set; }
        public bool IsUnderMaintenance { get; private set; }

        public Room(string roomNumber, string roomType, decimal nightlyRate)
        {
            if (nightlyRate <= 0)
                throw new ArgumentException("Nightly rate must be a positive value.");

            RoomNumber = roomNumber;
            RoomType = roomType;
            NightlyRate = nightlyRate;
            IsUnderMaintenance = false;
        }

        public void UpdateNightlyRate(decimal newRate)
        {
            if (newRate <= 0)
                throw new ArgumentException("Nightly rate must be a positive value.");

            NightlyRate = newRate;
        }

        public void Startmaintenance()
        {
            if (IsUnderMaintenance)
                throw new InvalidOperationException("Room is already under maintenance");
            IsUnderMaintenance = true;
        }

        public void Endmaintenance()
        {
            if (!IsUnderMaintenance)
                throw new InvalidOperationException("Room is not currently under maintenance");
            IsUnderMaintenance = false;
        }
    }
}