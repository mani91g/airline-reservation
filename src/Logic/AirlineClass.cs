using System;
using AirplaneReservation.Enums;
using AirplaneReservation.Interfaces;
using AirplaneReservation.Helpers;

namespace AirplaneReservation
{
    public class AirlineClass: IReservation{
        public void DisplaySeats(int[][][] jaggedArray){
            int i = 0;
            int j = 0;
            int k = 0;
            int iLast = jaggedArray.Length;
            int jLast = jaggedArray[iLast - 1].Length;
            int kLast = jaggedArray[i][jaggedArray[i].Length-1].Length;

            while(!(i >= iLast-1 && j >= jLast-1 && k >= kLast) && !(i > iLast-1 || j > jLast-1)){
                Console.Write(jaggedArray[i][j][k]+" ");
                ++k;

                //Check if rows in one section are filled
                if(k>=jaggedArray[i][j].Length){
                    Console.Write("\t");
                    ++i;

                    k = 0;
                }
                
                //Check if the entire row is filled
                if(i>=jaggedArray.Length){
                    Console.WriteLine();
                    ++j;
                    i = 0;
                }else{
                    //Update sections last row
                    kLast = jaggedArray[i][jaggedArray[i].Length-1].Length;
                }

                while(i < iLast && j >= jaggedArray[i].Length){
                    Console.Write("\t\t");
                    ++i;
                }
                    
            }
                
        }

        public void AllotSeats(int[][][] jaggedArray, int passengers, int passengerNumber, SeatType type){
            if(passengerNumber> passengers)
                return;

            int i = 0;
            int j = 0;
            int k = 0;
            int iLast = jaggedArray.Length;
            int jLast = jaggedArray[iLast - 1].Length;
            int kLast = jaggedArray[i][jaggedArray[i].Length-1].Length;

            while(!(i >= iLast-1 && j >= jLast-1 && k >= kLast) && passengerNumber <= passengers){
                if(SeatHelper.IsCorrectSeat(i, j, k, jaggedArray, type)){
                    jaggedArray[i][j][k] = passengerNumber;
                    passengerNumber++;
                }

                ++k;

                //Check if rows in one section are filled
                if(k>=jaggedArray[i][j].Length){                    
                    ++i;
                    
                    //Stop if right most and last seat reached
                    if(i >= iLast-1 && j >= jLast-1)
                        break;

                    k = 0;
                }
                
                //Check if the entire row is filled
                if(i>=jaggedArray.Length){
                    Console.WriteLine();
                    ++j;
                    i = 0;
                }else{
                    //Update sections last row
                    kLast = jaggedArray[i][jaggedArray[i].Length-1].Length;
                }

                while(i < iLast && j >= jaggedArray[i].Length){                    
                    ++i;
                }
                    
            }

            if(type == SeatType.AISLE)
                type = SeatType.WINDOW;
            else if(type == SeatType.WINDOW)
                type = SeatType.MIDDLE;


            AllotSeats(jaggedArray, passengers, passengerNumber, type);
                
        }

    }
}