using PersonalFinanceTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker.Infrastructure
{
    internal class BankAccountMapper
    {
        public void FromDto(
            BankAccount bankAccount, 
            BankAccountDto bankAccountDto) 
        {
            bankAccount.Id = bankAccountDto.Id;
            bankAccount.Name = bankAccountDto.Name;
            bankAccount.CurrencyType = bankAccountDto.CurrencyType;
            bankAccount.Balance = bankAccountDto.Balance;
            bankAccount.Transactions = bankAccountDto.Transactions;
        }
        public void ToDto(
            BankAccount bankAccount,
            BankAccountDto bankAccountDto)
        {
            bankAccountDto.Id = bankAccount.Id;
            bankAccountDto.Name = bankAccount.Name;
            bankAccountDto.CurrencyType = bankAccount.CurrencyType;
            bankAccountDto.Balance = bankAccount.Balance;
            bankAccountDto.Transactions = (List<TransactionDto>)bankAccount.Transactions;
        }
    }
}
