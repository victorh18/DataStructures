using DataStructures;
using System;

namespace DataStructures{
    public static class Sorter{

        public static void QuickSort(int[] numbers){
            //We need to know whether or not we needed to swap items
            bool swapped = false;

            //We search for incorrect items order at least once
            do{
                swapped = false;
                for(int i = 0; i < numbers.Length - 1; i++){
                    if(numbers[i] > numbers[i + 1]){
                        swapped = true;
                        int tempItem = numbers[i];
                        numbers[i] = numbers[i + 1];
                        numbers[i + 1] = tempItem;
                    }
                }

            } while(swapped);
        }
    }
}