using PersonalFinanceTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker.Application
{
    internal class TransferService
    {
        public void Transfer(
            BankAccount from, 
            BankAccount to, 
            decimal amount)
        {
            if (from.Id == to.Id) 
                throw new ArgumentException(
                    "You cannot transfer money to the same account!");
            if (amount <= 0) 
                throw new ArgumentException(
                    "The amount must be positive!");
            if (from.IsOpen != true || to.IsOpen != true) 
                throw new ArgumentException(
                    "Both accounts must be open!");
            if (from.CurrencyType != to.CurrencyType) 
                throw new ArgumentException(
                    "The currency of the accounts does not match!");
            from.Withdraw(amount);
            to.Deposit(amount);
        }
    }
}
