using System;
using System.Collections.Generic;
using System.Text;

namespace Merge_sort_Binary_Search
{
    class MergeSorter
    {
  
        public uint[] MergeSort(uint[] A, uint[] B, int n)
        {
            MergeObj mergeBox = new MergeObj();
            mergeBox = CopyToMergeObjA(mergeBox, A);
            mergeBox = TopDownMergeSort(A, B, n);
            B = mergeBox.B;
            return B;
        }

        static MergeObj CopyToMergeObjA(MergeObj mergeBox, uint[] A)
        {
            for (int i = 0; i < 256; i++)
            {
                mergeBox.A[i] = A[i];
            }
            return mergeBox;
        }
        static MergeObj CopyToMergeObjB(MergeObj mergeBox, uint[] B)
        {
            for (int i = 0; i < 256; i++)
            {
                mergeBox.B[i] = B[i];
            }
            return mergeBox;
        }
        static MergeObj TopDownMergeSort(uint[] A, uint[] B, int n)
        {
            n = 0;
            MergeObj mergeBox = new MergeObj();
            for (int i = 0; i < 256; i++)
            {
                if (A[i] != 0)
                {
                    n++;
                }
            }
            mergeBox = CopyArray(A, 0, n, B);                       // one time copy of A[] to B[]
            A = mergeBox.A;
            B = mergeBox.B;
            mergeBox = TopDownSplitMerge(B, 0, n, A);               // sort data from B[] into A[]
            return mergeBox;
        }
        static MergeObj CopyArray(uint[] A, int iBegin, int iEnd, uint[] B)
        {
            MergeObj mergeBox = new MergeObj();
            for (int k = iBegin; k < iEnd; k++)
            {
                B[k] = A[k];
            }

            mergeBox = CopyToMergeObjA(mergeBox, A);
            mergeBox = CopyToMergeObjB(mergeBox, B);
            return mergeBox;
        }
        static MergeObj TopDownSplitMerge(uint[] B, int iBegin, int iEnd, uint[] A)
        {
            MergeObj mergeBox = new MergeObj();

            if (iEnd - iBegin <= 1)
            {
                mergeBox = CopyToMergeObjA(mergeBox, A);
                mergeBox = CopyToMergeObjB(mergeBox, B);
                return mergeBox;
            }                                                     // if run size == 1
                                                                  // consider it sorted
                                                                  // split the run longer than 1 item into halves
            int iMiddle = (iEnd + iBegin) / 2;                    // iMiddle = mid point
                                                                  // recursively sort both runs from array A[] into B[]
            mergeBox = TopDownSplitMerge(A, iBegin, iMiddle, B);  // sort the left  run
            A = mergeBox.A;
            B = mergeBox.B;
            mergeBox = TopDownSplitMerge(A, iMiddle, iEnd, B);    // sort the right run
                                                                  // merge the resulting runs from array B[] into A[]
            A = mergeBox.A;
            B = mergeBox.B;
            mergeBox = TopDownMerge(B, iBegin, iMiddle, iEnd, A);
            return mergeBox;
        }

        static MergeObj TopDownMerge(uint[] A, int iBegin, int iMiddle, int iEnd, uint[] B)
        {
            int i = iBegin, j = iMiddle;
            MergeObj mergeBox = new MergeObj();
                                                                 // While there are elements in the left or right runs...
            for (int k = iBegin; k < iEnd; k++)
            {
                                                                 // If left run head exists and is <= existing right run head.
                if (i < iMiddle && (j >= iEnd || A[i] <= A[j]))
                {
                    B[k] = A[i];
                    i = i + 1;
                }
                else
                {
                    B[k] = A[j];
                    j = j + 1;
                }
            }
            mergeBox = CopyToMergeObjA(mergeBox, A);
            mergeBox = CopyToMergeObjB(mergeBox, B);
            return mergeBox;
        }
    }
}
