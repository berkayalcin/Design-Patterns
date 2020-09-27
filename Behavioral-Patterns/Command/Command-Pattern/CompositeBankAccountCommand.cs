using System.Collections.Generic;
using System.Linq;

namespace Command_Pattern
{
    public class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public CompositeBankAccountCommand()
        {
        }

        public CompositeBankAccountCommand(IEnumerable<BankAccountCommand> commands) : base(commands)
        {
        }

        public virtual void Call()
        {
            ForEach(cmd => cmd.Call());
        }

        public virtual void Undo()
        {
            foreach (var bankAccountCommand in ((IEnumerable<BankAccountCommand>) this).Reverse())
            {
                if (bankAccountCommand.Success)
                    bankAccountCommand.Undo();
            }
        }


        public virtual bool Success
        {
            get => this.All(cmd => cmd.Success);
            set
            {
                foreach (var bankAccountCommand in this) bankAccountCommand.Success = value;
            }
        }
    }

    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        private readonly BankAccount _from;
        private readonly BankAccount _to;
        private readonly int _amount;

        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            _from = @from;
            _to = to;
            _amount = amount;

            AddRange(new[]
            {
                new BankAccountCommand(from, BankAccountCommand.Action.Withdraw, amount),
                new BankAccountCommand(to, BankAccountCommand.Action.Deposit, amount),
            });
        }

        public override void Call()
        {
            BankAccountCommand last = null;
            foreach (var cmd in this)
            {
                if (last == null || last.Success)
                {
                    cmd.Call();
                    last = cmd;
                }
                else
                {
                    cmd.Undo();
                    break;
                }
            }
        }
    }
}