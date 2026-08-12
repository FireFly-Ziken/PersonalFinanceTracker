using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PersonalFinanceTracker
{
    internal class BankAccount
    {
        //private IReadOnlyCollection<Transaction> transactiond;
        public enum Currency {RUB, EUR, USD, GBP}

        public Guid Id { get; init; }
        public string Name { get; private set; }
        public decimal Balance { get; private set; } = decimal.Zero;
        public Currency CurrencyType { get; init; } 
        public DateTime DateOfCreation { get; init; } = DateTime.UtcNow;
        public bool IsOpen { get; private set; } = true;

        public BankAccount(string name, Currency currencyType) 
        {
            Id = Guid.NewGuid();
            if (String.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException("Длинна Name не может быть равна нулю, или состоять только из пробелов!");
            Name = name;
            CurrencyType = currencyType;
        }

        public void Deposit(decimal amount)
        {
            if (IsOpen is false) 
                throw new InvalidOperationException("Счет недействителен");
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    amount,
                    "Сумма должна быть положительной");
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            if (IsOpen is false) 
                throw new InvalidOperationException("Счет недействителен");
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    amount,
                    "Сумма должна быть положительной");
            if (Balance < amount) 
                throw new InvalidOperationException("Сумма не может быть больше баланса!");
            Balance -= amount;
        }
        public bool Close()
        {
            if (!IsOpen) return false;
            IsOpen = false;
            return true;
        }
    }
}
