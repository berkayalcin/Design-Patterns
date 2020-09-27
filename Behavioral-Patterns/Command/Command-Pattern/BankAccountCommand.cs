using System;

namespace Command_Pattern
{
    public class BankAccountCommand : ICommand
    {
        private BankAccount _bankAccount;
        private Action _action;
        private int _amount;
        private bool _succeded;


        public BankAccountCommand(BankAccount bankAccount, Action action, int amount)
        {
            _bankAccount = bankAccount ?? throw new ArgumentNullException(nameof(bankAccount));
            _action = action;
            _amount = amount;
        }

        public void Call()
        {
            switch (_action)
            {
                case Action.Deposit:
                    _succeded = _bankAccount.Deposit(_amount);
                    break;
                case Action.Withdraw:
                    _succeded = _bankAccount.Withdraw(_amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Undo()
        {
            if (!_succeded) return;

            switch (_action)
            {
                case Action.Deposit:
                    _bankAccount.Withdraw(_amount);
                    break;
                case Action.Withdraw:
                    _bankAccount.Deposit(_amount);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public bool Success { get; set; }

        public enum Action
        {
            Deposit,
            Withdraw
        }
    }
}