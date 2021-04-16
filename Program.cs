using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using AirplaneReservation.Interfaces;
using AirplaneReservation.Helpers;
using AirplaneReservation.Enums;

namespace AirplaneReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Input");
            string seatingInput = Console.ReadLine();
            Console.WriteLine("Enter Number of passengers");
            int passengers = int.Parse(Console.ReadLine());

            //Regex pattern to get input in format [[x1,y1],[x2, y2]]
            Regex pattern = new Regex(@"(\[([^\[]*?\]))");
            Match match = pattern.Match(seatingInput);

            if (match.Success){
                int[] inputArray = seatingInput.Replace("[","").Replace("]","").Replace(" ","").Split(',').Select(x => int.Parse(x)).ToArray();
                IReservation airlineClass = new AirlineClass();

                int[][][] jaggedArray = ArrayHelper.InitArray(inputArray);

                airlineClass.AllotSeats(jaggedArray, passengers > ArrayHelper.AvailableSeats ? ArrayHelper.AvailableSeats : passengers, 1, SeatType.AISLE);

                if(passengers > ArrayHelper.AvailableSeats)
                    Console.WriteLine($"{passengers-ArrayHelper.AvailableSeats} passengers do not have seats");

                airlineClass.DisplaySeats(jaggedArray);

            }
            else{
                Console.WriteLine("Incorrect input");
                return;
            }            
            
        }
    }
}
