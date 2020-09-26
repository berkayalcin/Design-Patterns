using System.Collections.Generic;

namespace Hated_Singleton
{
    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Db.GetPopulation(name);
            }

            return result;
        }
    }
}