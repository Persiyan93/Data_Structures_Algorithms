using System;

namespace Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 10, 7, 8, 9, 1, 5 };
            QuickSort(arr, 0, arr.Length - 1);
            Console.WriteLine(string.Join(" ,", arr));

        }
        static void QuickSort(int[]array,int low,int high)
        {
            if (low<high)
            {

                int pi = Partition(array, low, high);
                QuickSort(array, low, pi - 1);
                QuickSort(array, pi+1, high);
            }
        }
        static int Partition(int[] array,int first,int last)
        {
            int pivot = array[last];
            int i = first - 1;
            for (int j = first; j < last; j++)
            {
                if (array[j]<pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            int temp1 = array[i + 1];
            array[i + 1] = array[last];
            array[last] = temp1;
            return i + 1;
        }
    }
}
