using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace PersonalFinanceTracker.Service
{
    internal class JsonBankAccountRepository : IBankAccountRepository
    {
        private readonly string _filePath;
        public JsonBankAccountRepository(string filePath)
        {
            _filePath = filePath;
        }
        public IReadOnlyList<BankAccount> GetAll()
        {
            if (!File.Exists(_filePath)) 
                return [];
            string jsonString = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<BankAccount>>(jsonString) ?? [];
        }
        public BankAccount? Get(Guid id)
        {
            List<BankAccount>? bankAccounts = [.. GetAll()];

            return bankAccounts.FirstOrDefault(b => b.Id == id);
        }
        public void Delete(Guid id)
        {
            List<BankAccount> bankAccounts = [.. GetAll()];
            var bankAccount = bankAccounts.FirstOrDefault(b => b.Id == id);

            if (bankAccount is null)
                return;

            bankAccounts.Remove(bankAccount);
            SaveBankAccounts(bankAccounts);
        }

        public void Save(BankAccount bankAccount)
        {
            List<BankAccount> bankAccounts = [.. GetAll()];

            var indexBankAccount = bankAccounts.FindIndex(
                b => b.Id == bankAccount.Id);

            if (indexBankAccount == -1)
            {
                bankAccounts.Add(bankAccount);
            }
            else
            {
                bankAccounts[indexBankAccount] = bankAccount;
            }

            SaveBankAccounts(bankAccounts);
        }

        public void SaveBankAccounts(List<BankAccount> bankAccounts)
        {
            var jsonBankAccounts = JsonSerializer.Serialize(bankAccounts);

            File.WriteAllText(_filePath, jsonBankAccounts);
        }
    }
}
