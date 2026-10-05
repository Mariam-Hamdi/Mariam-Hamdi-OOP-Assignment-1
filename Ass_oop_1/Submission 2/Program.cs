namespace Submission_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== 1. Testing Room Creation & Pricing ===");

                Room room = new Room("204", "Suite", 1500m);
                Console.WriteLine($"Room Created: {room.RoomNumber} ({room.RoomType}), Rate: {room.NightlyRate} EGP");

                room.UpdateNightlyRate(1800m);
                Console.WriteLine($"Updated Nightly Rate: {room.NightlyRate} EGP");

                Console.WriteLine("\n=== 2. Testing Guest Creation ===");
                Guest guest = new Guest("G-99", "Mariam Hamdi", "01012345678");
                Console.WriteLine($"Guest Registered: {guest.FullName} (ID: {guest.GuestId})");

                Console.WriteLine("\n=== 3. Testing Reservation & Cost Calculation ===");
                Reservation reservation = new Reservation(
                    "RES-1001",
                    new DateTime(2026, 10, 10),
                    new DateTime(2026, 10, 14),
                    room
                );

                Console.WriteLine($"Reservation ID: {reservation.ReservationId}, Initial Status: {reservation.Status}");

                decimal totalCost = reservation.CalculateTotalCost();
                Console.WriteLine($"Calculated Total Cost: {totalCost} EGP");

                Console.WriteLine("\n=== 4. Testing Status Transitions ===");
                reservation.ConfirmReservation();
                Console.WriteLine($"Status after confirmation: {reservation.Status}");

                reservation.CheckInReservation();
                Console.WriteLine($"Status after check-in: {reservation.Status}");

                reservation.CheckOutReservation();
                Console.WriteLine($"Status after check-out: {reservation.Status}");

                guest.AddReservaion(reservation);
                Console.WriteLine($"Total reservations in guest history: {guest.Reservations.Count}");

                Console.WriteLine("\n=== All Tests Passed Successfully! ===");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[Test Failed / Exception Thrown]: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
