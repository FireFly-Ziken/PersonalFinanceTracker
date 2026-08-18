using PersonalFinanceTracker.Domain;
using PersonalFinanceTracker.Service;

var repository = new JsonBankAccountRepository("bankAccounts.json");

var account = new BankAccount("Oleg", Currency.RUB);

account.Deposit(10000);
account.Withdraw(3000);

repository.Save(account);

var loadedAccount = repository.Get(account.Id);

Console.WriteLine($"Balance: {loadedAccount?.Balance}");
Console.WriteLine($"Transactions: {loadedAccount?.Transactions.Count}");