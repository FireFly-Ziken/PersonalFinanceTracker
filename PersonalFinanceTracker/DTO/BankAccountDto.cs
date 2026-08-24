using PersonalFinanceTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker.DTO
{
    internal class BankAccountDto
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public decimal Balance { get; set; }
        public Currency CurrencyType { get; set; }
        public DateTime DateOfCreation { get; set; }
        public bool IsOpen { get; set; }
        public List<TransactionDto> Transactions { get; set; } = [];
    }
}
