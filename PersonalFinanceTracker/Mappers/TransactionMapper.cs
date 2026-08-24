using PersonalFinanceTracker.Domain;
using PersonalFinanceTracker.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PersonalFinanceTracker.Mapping
{
    internal class TransactionMapper
    {
        public static Domain.Transaction FromDto(
           TransactionDto transactionDto)
        {
            return Domain.Transaction.Restore(
                transactionDto.Id,
                transactionDto.Type,
                transactionDto.Amount,
                transactionDto.Date,
                transactionDto.Description
                );
        }
        public static TransactionDto ToDto(
            Domain.Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                Type = transaction.Type,
                Amount = transaction.Amount,
                Date = transaction.Date,
                Description = transaction.Description
            };

        }
    }
}

