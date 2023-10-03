using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingSortingRecursion
{
    public static class CollectionExtension
    {
        public static int BinarySearch<T>(this IEnumerable<T> collection, T item) where T : IComparable<T>
        {
            if (collection == null) throw new ArgumentNullException("collection");
            if (item == null) throw new ArgumentNullException("item");
            if (!collection.Any()) return -1;

            IList<T> list = collection is IList<T> ? (IList<T>)collection : new List<T>(collection);

            bool isAscending = true;
            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1].CompareTo(list[i]) > 0)
                {
                    isAscending = false;
                    break;
                }
            }

            if (!isAscending)
            {
                for (int i = 1; i < list.Count; i++)
                {
                    if (list[i - 1].CompareTo(list[i]) < 0)
                        throw new ArgumentException("Not sorted");
                }
            }

            int left = 0;
            int right = list.Count - 1;

            while (left <= right)
            {
                int middle = left + ((right - left) / 2);
                int comparison = list[middle].CompareTo(item);

                if (comparison == 0) return middle;
                else if (isAscending ? comparison < 0 : comparison > 0) left = middle + 1;
                else right = middle - 1;
            }

            return -1;
        }
        public static IEnumerable<T> QuickSort<T>(this IEnumerable<T> collection) where T: IComparable<T>
        {
            var list = new List<T>(collection);
            QuickSort(list, 0, list.Count - 1);
            return list;
        }
        private static void QuickSort<T>(IList<T> list, int left, int right) where T : IComparable<T> 
        { 
            if (left < right)
            {
                int pivotIndex = Partition(list,left, right);
                QuickSort(list, left, pivotIndex - 1);
                QuickSort(list,pivotIndex + 1, right);
            }
        }
        private static int Partition<T>(IList<T> list, int left, int right) where T : IComparable<T>
        {
            var pivot = list[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (list[j].CompareTo(pivot) < 0)
                {
                   Swap(list,i,j);
                }
            }

            Swap(list,i,right);
            return i;
        }
        private static void Swap<T>(IList<T> list, int i, int j)
        {
            var temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}
