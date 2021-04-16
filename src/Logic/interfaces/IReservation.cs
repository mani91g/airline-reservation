using AirplaneReservation.Enums;
namespace AirplaneReservation.Interfaces
{
    interface IReservation{
        void AllotSeats(int[][][] jaggedArray, int passengers, int passengerNumber, SeatType type);
        void DisplaySeats(int[][][] jaggedArray);
    }
}