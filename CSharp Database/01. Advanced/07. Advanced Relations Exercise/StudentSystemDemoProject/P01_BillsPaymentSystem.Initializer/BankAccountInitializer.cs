using P01_BillsPaymentSystem.Data.Models;
using System;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class BankAccountInitializer
    {
        internal static BankAccount[] GetBankAccounts()
        {
            var bankAccounts = new BankAccount[]
            {
                new BankAccount(){SwiftCode = "AHGHU", BankName = "Bank Of Credits"},
                new BankAccount(){SwiftCode = "AHUIH", BankName = "Bank Of Payments"},
                new BankAccount(){SwiftCode = "KOIUJ", BankName = "Bank Of Loans"},
                new BankAccount(){SwiftCode = "LOKQW", BankName = "Bank Of Sharks"},
                new BankAccount(){SwiftCode = "JIJUH", BankName = "Bank Of BadPeople"}
            };

            bankAccounts[0].Deposit(58600);
            bankAccounts[1].Deposit(56940);
            bankAccounts[2].Deposit(300);
            bankAccounts[3].Deposit(150);
            bankAccounts[4].Deposit(1540);

            return bankAccounts;
        }
    }
}
