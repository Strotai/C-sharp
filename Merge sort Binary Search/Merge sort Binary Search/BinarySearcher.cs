using System;
using System.Collections.Generic;
using System.Text;

namespace Merge_sort_Binary_Search
{
    class BinarySearcher
    {
        public int BinarySearch(uint[] list, int n, uint target)
        {
            int index = n / 2;
            while (list[index] != target)
            {
                if(list[index] > target)
                {
                    index = index + index / 2;
                }
                else if(list[index] > target){
                    index = index - index / 2;
                }
            }
            return index;
        }


    }
}
