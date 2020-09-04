using System;
using System.Collections.Generic;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Sort(array);
        }
        static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {

                bool swap = false;
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swap = true;
                    }
                }
                if (swap == false)
                {
                    break;
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
       
    }
}
