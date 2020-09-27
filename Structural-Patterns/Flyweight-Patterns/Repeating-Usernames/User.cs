using System;

namespace Repeating_Usernames
{
    public class User
    {
        private string _fullName;

        public User(string fullName)
        {
            _fullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        }
    }
}