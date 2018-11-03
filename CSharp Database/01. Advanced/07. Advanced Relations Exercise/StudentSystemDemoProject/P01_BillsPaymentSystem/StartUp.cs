﻿using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;
using P01_BillsPaymentSystem.Initializer;
using System;
using System.Globalization;
using System.Linq;

namespace P01_BillsPaymentSystem
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Initialize.Seed(context);

                Console.WriteLine("UserId: ");
                var userId = int.Parse(Console.ReadLine());

                User user = GetUser(userId, context);
                GetInfo(user);

                Console.WriteLine(Environment.NewLine + "Please enter bill to pay:");
                decimal amount = decimal.Parse(Console.ReadLine());

                string paymentResult = PayBills(user, amount);
                Console.WriteLine(paymentResult);
                context.SaveChanges();
            }
        }

        private static string PayBills(User user, decimal amount)
        {
            if (user == null)
            {
                return "User does not exisit!";
            }

            var bankAccountTotals = user.PaymentMethods.Where(x => x.BankAccount != null).Sum(x => x.BankAccount.Balance);
            var creditCardTotals = user.PaymentMethods.Where(x => x.CreditCard != null).Sum(x => x.CreditCard.LimitLeft);

            var totalAmount = bankAccountTotals + creditCardTotals;

            var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null)
                                                  .Select(x => x.BankAccount)
                                                  .OrderBy(x => x.BankAccountId)
                                                  .ToArray();

            foreach (var bankAccount in bankAccounts)
            {
                if (bankAccount.Balance >= amount)
                {
                    bankAccount.Withdraw(amount);
                    amount = 0;
                }
                else
                {
                    amount -= bankAccount.Balance;
                    bankAccount.Withdraw(bankAccount.Balance);
                }

                if (amount == 0)
                {
                    return "All bills payd sucessfuly!";
                }
            }

            var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null)
                                                  .Select(x => x.CreditCard)
                                                  .OrderBy(x => x.CreditCardId)
                                                  .ToArray();

            foreach (var creditCard in creditCards)
            {
                if (creditCard.LimitLeft >= amount)
                {
                    creditCard.Withdraw(amount);
                    amount = 0;
                }
                else
                {
                    amount -= creditCard.LimitLeft;
                    creditCard.Withdraw(creditCard.LimitLeft);
                }

                if (amount == 0)
                {
                    return "All bills payd sucessfuly!";
                }
            }


            return "insufficient money in all bank accounts and credit cards";

        }

        private static void GetInfo(User user)
        {
            Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            Console.WriteLine("Bank Accounts:");

            var bankAccounts = user.PaymentMethods.Where(x => x.BankAccount != null).Select(x => x.BankAccount).ToArray();

            foreach (var bankAccount in bankAccounts)
            {
                Console.WriteLine($"-- ID: {bankAccount.BankAccountId}");
                Console.WriteLine($"--- Balance: {bankAccount.Balance:F2}");
                Console.WriteLine($"--- Bank: {bankAccount.BankName}");
                Console.WriteLine($"--- SWIFT: {bankAccount.SwiftCode}");
            }

            var creditCards = user.PaymentMethods.Where(x => x.CreditCard != null).Select(x => x.CreditCard).ToArray();

            Console.WriteLine("Credit Cards:");

            foreach (var creditCard in creditCards)
            {
                Console.WriteLine($"-- ID: {creditCard.CreditCardId}");
                Console.WriteLine($"--- Limit: {creditCard.Limit:F2}");
                Console.WriteLine($"--- Money Owed: {creditCard.MoneyOwed:F2}");
                Console.WriteLine($"--- Limit Left:: {creditCard.LimitLeft:F2}");
                Console.WriteLine($"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM")}");
            }
        }

        private static User GetUser(int userId, BillsPaymentSystemContext context)
        {
            User user = user = context.Users
                .Where(x => x.UserId == userId)
                .Include(x => x.PaymentMethods)
                .ThenInclude(x => x.BankAccount)
                .Include(x => x.PaymentMethods)
                .ThenInclude(x => x.CreditCard)
                .FirstOrDefault();

                if (user == null)
                {
                Console.WriteLine($"User with id {userId} not found!");
                Console.WriteLine("Please enter valid user Id");
                }
            

            return user;
        }
    }
}
