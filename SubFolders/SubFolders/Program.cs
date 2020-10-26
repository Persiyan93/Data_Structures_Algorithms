using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;

namespace SubFolders
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> result = new List<string>();

            //BFSSubFolders(result, "D:\\flash");
            //Console.WriteLine(string.Join('\n', result));
            RecursiveSubFolders("D:\\flash", result);
            Console.Write(string.Join('\n', result));



        }
        static private void BFSSubFolders(List<string> result, string folderPath)
        {
            Queue<string> folders = new Queue<string>();
            folders.Enqueue(folderPath);

            while (folders.Count != 0)
            {
                folderPath = folders.Dequeue();
                string[] currentSubFolders = Directory.GetDirectories(folderPath);
                result.Add("--" + folderPath);
                foreach (var item in currentSubFolders)
                {
                    folders.Enqueue(item);
                }
            }


        }
        static private void RecursiveSubFolders(string path, List<string> result)
        {
            string[] subfolders = Directory.GetDirectories(path);

            string emptySpace = " ";
            foreach (var item in subfolders)
            {
                RecursiveSubFolders(item, result);
                emptySpace += " ";
            }
            result.Add(emptySpace + path);
        }

    }
}
