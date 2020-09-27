using System.Collections.Generic;
using System.Linq;

namespace Repeating_Usernames
{
    public class OptimizedUser
    {
        static List<string> _strings = new List<string>();
        private int[] _names;

        public OptimizedUser(string fullName)
        {
            int getOrAdd(string s)
            {
                int idx = _strings.IndexOf(s);
                if (idx != -1) return idx;
                _strings.Add(s);
                return _strings.Count - 1;
            }

            _names = fullName.Split(' ').Select(getOrAdd).ToArray();
        }

        public string FullName => string.Join(' ',
            _names.Select(n => _strings[n])
        );
    }
}