using System;
using System.Linq;
using System.Collections.Generic;

namespace AirplaneReservation.Helpers
{
    public static class ArrayHelper{

        public static int AvailableSeats = 0;
        //Init 3D Array
        public static int[][][] InitArray(int[] inputArray){
            int[][][] jaggedArray = new int[inputArray.Length/2][][];

                for(int i = 0; i < inputArray.Length/2; i++){
                    int index = i * 2;                    
                    jaggedArray[i] = ArrayHelper.Init2DArray(inputArray[index], inputArray[index+1]);
                    AvailableSeats = AvailableSeats + inputArray[index]*inputArray[index+1];
                }
            
            return jaggedArray;
        }

        //Method to initialize array with default values
        public static int[][] Init2DArray(int count, int size){
            int[][] resultArray = new int[size][];
            
            for(int i = 0; i < resultArray.Length; i++){
                resultArray[i] = getDefaultArray(count);
            }

            return resultArray;

        }
        private static int[] getDefaultArray(int count){
            int[] defaultArray = new int[count];
            defaultArray.ToList().ForEach(i => i = 0);

            return defaultArray;
        }
    }
}