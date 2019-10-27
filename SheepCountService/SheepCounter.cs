using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheepCountService
{
    public static class SheepCounter
    {
        private static readonly ConcurrentBag<int> SheepDataStore = new ConcurrentBag<int>();

        public static ConcurrentBag<int> GetSheepCounter()
        {
            return SheepDataStore;
        }

    }
}
