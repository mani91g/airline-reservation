using AirplaneReservation.Enums;

namespace AirplaneReservation.Helpers
{
    
    public static class SeatHelper{

        //Method to select seating position
        public static bool IsCorrectSeat(int i, int j, int k, int[][][] jaggedArray, SeatType type){
            switch(type){
                case SeatType.AISLE:
                    return isAisleSeat(i, j, k, jaggedArray);
                case SeatType.WINDOW:
                    return isWindowSeat(i, j, k, jaggedArray);
                case SeatType.MIDDLE:
                    return isMiddleSeat(i, j, k, jaggedArray);
                default:
                    return false;
            }

        }
         //Check if the seat is a window seat
        private static bool isWindowSeat(int i, int j, int k, int[][][] jaggedArray){
            int iLast = jaggedArray.Length - 1;
            int jLast = jaggedArray[iLast-1].Length -1;
            int kLast = jaggedArray[iLast][jLast].Length - 1;
            if((i == 0 && k == 0) || (i == jaggedArray.Length -1 && k == kLast)){
                return true;
            }

            return false;
        }

        //Check if the seat is a aisle seat
        private static bool isAisleSeat(int i, int j, int k, int[][][] jaggedArray){
            int kLast = jaggedArray[i][j].Length -1;

            if(!(isWindowSeat(i, j, k, jaggedArray)) && (k == 0 || k == kLast)){
                return true;
            }

            return false;
        }

        //Check if the seat is a middle seat
        private static bool isMiddleSeat(int i, int j, int k, int[][][] jaggedArray){
            return !(isAisleSeat(i, j, k, jaggedArray)) && !(isWindowSeat(i, j, k, jaggedArray));
        }
    }
}