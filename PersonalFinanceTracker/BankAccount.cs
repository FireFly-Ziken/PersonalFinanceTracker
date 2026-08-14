using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace PersonalFinanceTracker
{
    internal class BankAccount
    {
        private readonly List<Transaction> _transactions = [];
        public IReadOnlyCollection<Transaction> Transactions => _transactions;

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
                throw new ArgumentException(
                    "The length of Name cannot be zero or consist only of spaces!");
            Name = name;
            CurrencyType = currencyType;
        }

        public void Deposit(decimal amount)
        {
            if (IsOpen is false) 
                throw new InvalidOperationException("Account is invalid");
            if (amount <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    amount,
                    "The amount must be positive");
            Balance += amount;
            _transactions.Add(new Transaction(TransactionType.Deposit, amount, "Replenishment")); 
        }
        public void Withdraw(decimal amount)
        {
            if (IsOpen is false) 
                throw new InvalidOperationException("Account is invalid");
            if(amount <= 0)
                throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    amount,
                    "The amount must be positive");
            if (Balance < amount) 
                throw new InvalidOperationException("The amount cannot be greater than the balance.!");
            Balance -= amount;
            _transactions.Add(new Transaction(TransactionType.Withdraw, amount, "Withdrawal"));
        }
        public bool Close()
        {
            if (!IsOpen) return false;
            IsOpen = false;
            return true;
        }
    }
}
