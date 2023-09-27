using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListBinarySearch
{
    public static class ListExtensions
    {
        public static int BinarySearch<T>(this List<T> list, T item) where T : IComparable<T>
        {
            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int middle = left + (right + left) / 2;
                int comparison = list[middle].CompareTo(item);

                if (comparison == 0) return middle;
                else if (comparison < 0) left = middle + 1;
                else right = middle - 1;
            }

            return -1;

        }

    }
}
