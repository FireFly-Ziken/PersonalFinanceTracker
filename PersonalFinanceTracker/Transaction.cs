using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker
{
    internal class Transaction
    {
        public Guid Id { get; init; }
        public TransactionType Type { get; init; }
        public decimal Amount { get; init; }
        public DateTime Date {  get; init; } = DateTime.UtcNow;
        public string Description { get; init; } 

        public Transaction(TransactionType transactionType, decimal amount, string description)
        {
            Id = Guid.NewGuid();
            Type = transactionType;
            if (amount <= 0) throw new ArgumentOutOfRangeException(
                    nameof(amount),
                    amount,
                    "Сумма должна быть положительной");
            Amount = amount;
            if (String.IsNullOrWhiteSpace(description))
                throw new ArgumentException(
                    "Описание не может быть пустым.",
                    nameof(description));
            Description = description;
        }
    }
}
