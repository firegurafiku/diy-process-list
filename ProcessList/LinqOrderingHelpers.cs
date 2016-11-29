using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessList
{
    public static class LinqOrderingHelpers
    {
        public static bool IsOrderedAscending<T>(this IEnumerable<T> sequence)
            where T : IComparable<T>
        {
            return sequence.IsOrderedAscending(x => x);
        }

        public static bool IsOrderedAscending<T, K>(
            this IEnumerable<T> sequence,
            Func<T, K> keySelector)
            where K : IComparable<K>
        {
            return sequence.IsOrderedAscending(keySelector.GetComparison());
        }

        public static bool IsOrderedAscending<T>(
            this IEnumerable<T> sequence, Comparison<T> comparison)
        {
            T prevItem = default(T);
            bool hasPrev = false;
            foreach (var item in sequence)
            {
                if (hasPrev)
                {
                    if (comparison(prevItem, item) > 0)
                        return false;
                }

                prevItem = item;
                hasPrev = true;
            }

            return true;
        }

        public static bool IsOrderedDescending<T>(this IEnumerable<T> sequence)
            where T : IComparable<T>
        {
            return IsOrderedDescending(sequence, x => x);
        }

        public static bool IsOrderedDescending<T, K>(
            this IEnumerable<T> sequence,
            Func<T, K> keySelector)
            where K : IComparable<K>
        {
            return IsOrderedDescending(sequence, keySelector.GetComparison());
        }

        public static bool IsOrderedDescending<T>(
            this IEnumerable<T> sequence, Comparison<T> comparison)
        {
            return sequence.IsOrderedAscending(comparison.FlipComparison());
        }
    }
}
