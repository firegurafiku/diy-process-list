using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProcessList
{
    using ProcessList;

    internal static class AssertEx
    {
        public static void AreSameSequences<T>(IEnumerable<T> first, IEnumerable<T> second) {
            Assert.IsNotNull(first);
            Assert.IsNotNull(second);
            Assert.IsTrue(first.SequenceEqual(second));
        }

        public static void AreSameSets<T>(IEnumerable<T> first, IEnumerable<T> second)
        {
            Assert.IsNotNull(first);
            Assert.IsNotNull(second);
            Assert.IsTrue(first.ToHashSet().SetEquals(second));
        }
    }
}
