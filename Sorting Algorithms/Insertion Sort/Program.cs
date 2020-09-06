using System;
using System.Linq;

namespace Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Sort(array);
            Console.WriteLine(string.Join(", ", array));
        }
        static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int currentnumber = array[i];
                int j = i - 1;

                while (j>=0&&array[j]>currentnumber)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = currentnumber;
            }
        }
    }
}
