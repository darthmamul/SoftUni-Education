using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class CreditCardInitializer
    {
        internal static CreditCard[] GetCreditCards()
        {
            CreditCard[] creditCards = new CreditCard[]
            {
                new CreditCard(){Limit = 30000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 6000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 400, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 50000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 125, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 15000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 1000000, ExpirationDate = DateTime.Now.AddYears(1)},
                new CreditCard(){Limit = 12000, ExpirationDate = DateTime.Now.AddYears(1)},
            };

            creditCards[0].Deposit(600);
            creditCards[1].Deposit(15);
            creditCards[2].Deposit(12000);
            creditCards[3].Deposit(35000);
            creditCards[4].Deposit(787);
            creditCards[5].Deposit(3500);
            creditCards[6].Deposit(750);
            creditCards[7].Deposit(4);

            return creditCards;
        }
    }
}
