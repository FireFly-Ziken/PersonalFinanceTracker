using PersonalFinanceTracker.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker.Infrastructure
{
    internal interface IBankAccountRepository
    {
        IReadOnlyList<BankAccount> GetAll();
        BankAccount? Get(Guid id);
        void Save(BankAccount bankAccount);
        void Delete(Guid id);

    }
}
