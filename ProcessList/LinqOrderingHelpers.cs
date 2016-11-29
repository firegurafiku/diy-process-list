using System;
using System.Collections.Generic;

namespace ProcessList
{
    // This class contains a bunch of methods for checking whether sequence is
    // ordered ascending or descending (not strictly ascending or or descending,
    // though). I was unable to find simular functions in the standard library,
    // so I rolled out my own implementations. I should have tested them, too;
    // but I lack time for it, sorry.
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
