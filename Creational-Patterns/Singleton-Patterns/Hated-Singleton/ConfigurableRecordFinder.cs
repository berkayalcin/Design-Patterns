using System;
using System.Collections.Generic;

namespace Hated_Singleton
{
    public class ConfigurableRecordFinder
    {
        private IDatabase _database;

        public ConfigurableRecordFinder(IDatabase database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += _database.GetPopulation(name);
            }

            return result;
        }
    }
}