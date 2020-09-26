using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq.Extensions;

namespace Hated_Singleton
{
    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;


        public OrdinaryDatabase()
        {
            Console.WriteLine("Initializating Database");
            _capitals = File.ReadAllLines("capitals.txt")
                .Batch(2)
                .ToDictionary(e => e.ElementAt(0).Trim(),
                    e => int.Parse(e.ElementAt(1)));
        }

        public int GetPopulation(string name)
        {
            return _capitals[name];
        }
    }
}