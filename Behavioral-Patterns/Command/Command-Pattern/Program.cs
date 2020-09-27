using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var bankAccount = new BankAccount();

            var commands = new List<BankAccountCommand>()
            {
                new BankAccountCommand(bankAccount, BankAccountCommand.Action.Deposit, 100),
                new BankAccountCommand(bankAccount, BankAccountCommand.Action.Withdraw, 1000),
            };

            WriteLine(bankAccount);

            foreach (var bankAccountCommand in commands) bankAccountCommand.Call();

            WriteLine(bankAccount);

            foreach (var bankAccountCommand in Enumerable.Reverse(commands)) bankAccountCommand.Undo();

            WriteLine(bankAccount);
        }
    }
}