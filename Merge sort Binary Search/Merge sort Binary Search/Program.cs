using System;
using System.Transactions;

namespace Merge_sort_Binary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            uint[] A = new uint[256];
            uint[] B = new uint[256];
            MergeSorter MS = new MergeSorter();
            int n = 0;
            A = EnterUserNumbers();
            for (int i = 0; i < 256; i++)
            {
                if (A[i] != 0)
                {
                    n++;
                    Console.Write(A[i]);
                    Console.Write(" ");
                }
            }
            B = MS.MergeSort(A, B, n);
            Console.WriteLine();
            Console.WriteLine(n);
            for (int i = 0; i < 256; i++)
            {
                if (B[i] != 0)
                {
                    Console.Write(B[i]);
                    Console.Write(" ");
                }
            }

            Console.WriteLine("enter a number to search for...");
            uint target = (uint)Convert.ToInt32(Console.ReadLine());
            BinarySearcher BS = new BinarySearcher();
            int indexOf = BS.BinarySearch(B, n, target);
            Console.WriteLine("target holds index: " + indexOf);
        }

        static uint[] EnterUserNumbers()
        {
            uint[] text = new uint[256];
            uint current = 1;
            int index = 0;
            while (current != 0)
            {
                Console.WriteLine("Press 0 to exit");
                Console.WriteLine("Size: " +  index);
                current = (uint)Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                text[index] = current;
                index++;
            }
            return text;
        } 
     


    }
}
