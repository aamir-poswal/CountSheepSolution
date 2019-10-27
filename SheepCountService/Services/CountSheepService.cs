using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SheepCountService
{
    public class CountSheepService : ICountSheepService, IAddSheepService
    {
        private readonly ConcurrentBag<int> inMemoryDatabase = SheepCounter.GetSheepCounter();


        public void AddSheep(int count)
        {
            for (int i = 0; i < count; i++)
            {
                inMemoryDatabase.Add(i);
            }
        }

        public int GetSheepCount()
        {
            return inMemoryDatabase.Count();
        }
    }
}
