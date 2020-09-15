using System;

namespace Merge_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 7,3,5,4,9,12,3 };
            MergeSort(array);
            Console.WriteLine(string.Join(", ", MergeSort(array)));

        }
        private static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            int middle = array.Length / 2;
            int[] leftarray = new int[array.Length / 2];
            int[] rightarray = new int[array.Length -middle];
            
            for (int i = 0; i < middle; i++)
            {
                leftarray[i] = array[i];
              
            }
            
            for (int i = 0; i < rightarray.Length; i++)
            {
                rightarray[i] = array[i+middle];
                
            }
            leftarray = MergeSort(leftarray);
            rightarray = MergeSort(rightarray);
            return Merge(leftarray, rightarray);
        }
        private static int[] Merge(int[] leftarray, int[] rightarray)
        {
            int[] result = new int[leftarray.Length +rightarray.Length];
            int i = 0;
            int j = 0;
            int k = 0;

            while (leftarray.Length > i || rightarray.Length > j)
            {
                if (leftarray.Length > i && rightarray.Length > j)
                {
                    if (leftarray[i] <= rightarray[j])
                    {
                        result[k] = leftarray[i];
                        i++;

                    }
                    else
                    {
                        result[k] = rightarray[j];
                        j++;
                    }
                    k++;
                }
                else if (leftarray.Length>i)
                {
                    result[k] = leftarray[i];
                    i++;
                    k++;
                }
                else
                {
                    result[k] = rightarray[j];
                    j++;
                    k++;
                }
               

            }
            return result;

        }


    }
}
