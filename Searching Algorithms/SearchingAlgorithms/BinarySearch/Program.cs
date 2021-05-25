using System;
using System.Linq;

namespace BinarySearch
{
    class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Please enter array :");
            int[] arr = Console.ReadLine().Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Console.WriteLine("Position of searched number:");
            Console.WriteLine(RecursiveBinarySearch(arr, 9, 0, 7));
        }
        private static int RecursiveBinarySearch(int[] arr, int searchedElement,int firstIndex,int lastIndex)
        {
            if (lastIndex >= firstIndex)
            {

                int middle =firstIndex+(lastIndex-firstIndex)/ 2;
                if (arr[middle] == searchedElement)
                {
                    return middle;
                }

                else if (arr[middle] > searchedElement)
                {
                    RecursiveBinarySearch(arr, searchedElement, firstIndex, middle - 1);
                }
                else if (arr[middle] < searchedElement)
                {
                    RecursiveBinarySearch(arr, searchedElement, middle + 1, lastIndex);
                }
                
            }
            //Return -1 if number is not exist in array
            return  -1;
            
        }
    }
}
