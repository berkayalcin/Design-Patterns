using System;
using System.Linq;

namespace Repeating_Usernames
{
    public class Helpers
    {
        public void ForceGC()
        {
            GC.Collect();

            GC.WaitForPendingFinalizers();

            GC.Collect();
        }

        public string RandomString()
        {
            Random rand = new Random();
            return new string(
                Enumerable
                    .Range(0, 10)
                    .Select(i => (char) ('a' + rand.Next(26)))
                    .ToArray()
            );
        }
    }
}