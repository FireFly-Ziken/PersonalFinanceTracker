using PersonalFinanceTracker.Domain;
using PersonalFinanceTracker.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker.Mapping
{
    internal class BankAccountMapper
    {
        public static BankAccount FromDto(
            BankAccountDto bankAccountDto) 
        {
            List<Transaction> transactions = new();
            foreach (var transaction in bankAccountDto.Transactions)
            {
                transactions
                    .Add(TransactionMapper
                    .FromDto(transaction));
            }
            return BankAccount.Restore(
                bankAccountDto.Id,
                bankAccountDto.Name,
                bankAccountDto.Balance,
                bankAccountDto.CurrencyType,
                bankAccountDto.DateOfCreation,
                bankAccountDto.IsOpen,
                transactions);
        }
        public static BankAccountDto ToDto(
            BankAccount bankAccount)
        {
            List<TransactionDto> transactionDtos = new();
            foreach (Transaction transaction in bankAccount.Transactions)
            {
                transactionDtos
                    .Add(TransactionMapper
                    .ToDto(transaction));
            }
            return new BankAccountDto
            {
                Id = bankAccount.Id,
                Name = bankAccount.Name,
                Balance = bankAccount.Balance,
                CurrencyType = bankAccount.CurrencyType,
                DateOfCreation = bankAccount.DateOfCreation,
                IsOpen = bankAccount.IsOpen,
                Transactions = transactionDtos
            };
        }
    }
}
