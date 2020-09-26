using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MoreLinq.Extensions;

namespace Hated_Singleton
{
    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;
        private static int _instanceCount = 0;

        public static int Count => _instanceCount;

        public SingletonDatabase()
        {
            _instanceCount++;
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

        private static readonly Lazy<SingletonDatabase> Instance = new Lazy<SingletonDatabase>(() =>
            new SingletonDatabase());

        public static SingletonDatabase Db => Instance.Value;
    }
}