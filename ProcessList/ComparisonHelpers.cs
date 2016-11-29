using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessList
{
    // Some helper functions for Comparison<T>. Strictly speaking, I should have
    // unit-tested them, but I really lack time for it. They're quite obvious and
    // functional-style, and should contain no errors.
    public static class ComparisonHelpers
    {
        public static Comparison<T> FlipComparison<T>(this Comparison<T> comparison)
        {
            // Note that we may not simply negate the comparison result, as
            // that number may legally be equal to 'int.IntMin' which doesn't
            // have a corresponding positive number.
            return (first, second) => comparison(second, first);
        }

        public static int NullAwareComparison<T>(T first, T second)
            where T : IComparable<T>
        {
            return first == null ? -1 : first.CompareTo(second);
        }

        public static int NullAwareComparison0<T>(T first, T second)
            where T : IComparable
        {
            return first == null ? -1 : first.CompareTo(second);
        }

        // Some sorting methods take a Comparison<T> object (e.g. List.Sort), others (Linq)
        // take key selector. This routine allow to easily convert between them if necessary.
        public static Comparison<T> GetComparison<T, K>(this Func<T, K> keySelector)
            where K : IComparable<K>
        {
            return (first, second) => NullAwareComparison(keySelector(first),
                                                          keySelector(second));
        }
    }
}
