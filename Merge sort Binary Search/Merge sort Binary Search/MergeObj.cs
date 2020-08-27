using System;
using System.Collections.Generic;
using System.Text;

namespace Merge_sort_Binary_Search
{
    class MergeObj
    {
        private uint[] a, b;
        public MergeObj()
        {
            a = new uint[256];
            b = new uint[256];
        }


        public uint[] A
        {
            get { return a; }
            set { A = value; }  // set method
        }

        public uint[] B
        {
            get { return b; }
            set { B = value; }  // set method
        }
    }
}
