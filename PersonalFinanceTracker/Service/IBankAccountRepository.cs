using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalFinanceTracker.Service
{
    internal interface IBankAccountRepository
    {
        IReadOnlyList<BankAccount> GetAll();
        BankAccount? Get(Guid id);
        void Save(BankAccount bankAccount);
        void Delete(Guid id);

    }
}
