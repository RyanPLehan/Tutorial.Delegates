using System;
using System.Collections.Generic;
using System.Linq;

namespace Tutorial.Delegates
{
    internal static class Repository
    {
        public static IEnumerable<int> GetData(int size) => Enumerable.Range(1, size);
    }
}
