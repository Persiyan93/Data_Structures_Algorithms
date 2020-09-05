using System;
using System.Linq;

namespace Selection_sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Sort(array);
            Console.WriteLine(string.Join(", ", array));

        }
        public static void Sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;

                    }

                    if (minIndex == i)
                    {
                        break;
                    }
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;

                }
            }

        }
    }
