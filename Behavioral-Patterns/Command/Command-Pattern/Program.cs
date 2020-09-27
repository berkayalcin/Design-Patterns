using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Command_Pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = new BankAccount();
            from.Deposit(100);

            var to = new BankAccount();


            var mtc = new MoneyTransferCommand(from, to, 100);
            mtc.Call();

            WriteLine(from);
            WriteLine(to);

            mtc.Undo();
            WriteLine(from);
            WriteLine(to);
        }
    }
}