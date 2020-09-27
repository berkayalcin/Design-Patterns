using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.dotMemoryUnit;
using JetBrains.dotMemoryUnit.Kernel;
using NUnit.Framework;

namespace Repeating_Usernames
{
    [TestFixture]
    public class UserTests
    {
        private readonly Helpers _helpers = new Helpers();

        [Test]
        public void UserMemoryTest() // 1655033
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => _helpers.RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => _helpers.RandomString());

            var users = new List<User>();
            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new User($"{firstName} {lastName}"));
                }
            }

            _helpers.ForceGC();

            if (dotMemoryApi.IsEnabled)
            {
                dotMemory.Check(memory => { Console.Write(memory.SizeInBytes); });
            }
        }

        [Test]
        public void OptimizedUserMemoryTest() // 1296991
        {
            var firstNames = Enumerable.Range(0, 100).Select(_ => _helpers.RandomString());
            var lastNames = Enumerable.Range(0, 100).Select(_ => _helpers.RandomString());

            var users = new List<OptimizedUser>();
            foreach (var firstName in firstNames)
            {
                foreach (var lastName in lastNames)
                {
                    users.Add(new OptimizedUser($"{firstName} {lastName}"));
                }
            }

            _helpers.ForceGC();

            if (dotMemoryApi.IsEnabled)
            {
                dotMemory.Check(memory => { Console.Write(memory.SizeInBytes); });
            }
        }
    }
}