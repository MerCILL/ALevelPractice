using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class ListExtensions
    {
        public static T FirstOrDefault2<T>(this List<T> list, Func<T, bool> predicate)
        {
            foreach (var item in list) 
            {
                if(predicate(item)) return item;
            }
            return default(T);
        }

        public static IEnumerable<T> SkipWhile2<T>(this List<T> list, Func<T, bool> predicate)
        {
            bool skipCondition = false;

            foreach (var item in list)
            {
                if (!skipCondition && predicate(item)) continue;

                skipCondition = true;
                yield return item;
            }
        }

    }


}
