using P01_BillsPaymentSystem.Data.Models;
using P01_BillsPaymentSystem.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class PaymentMethodInitializer
    {
        internal static PaymentMethod[] GetPaymentMethods()
        {
            var paymentMethods = new PaymentMethod[]
            {
                new PaymentMethod(){UserId = 1, Type = PaymentType.BankAccout, BankAccountId = 1},
                new PaymentMethod(){UserId = 1, Type = PaymentType.BankAccout, BankAccountId = 2},
                new PaymentMethod(){UserId = 1, Type = PaymentType.CreditCard, CreditCardid = 1},
                new PaymentMethod(){UserId = 1, Type = PaymentType.CreditCard, CreditCardid = 5},
                new PaymentMethod(){UserId = 2, Type = PaymentType.BankAccout, BankAccountId = 3},
                new PaymentMethod(){UserId = 3, Type = PaymentType.CreditCard, CreditCardid = 2},
                new PaymentMethod(){UserId = 4, Type = PaymentType.CreditCard, CreditCardid = 3},
                new PaymentMethod(){UserId = 5, Type = PaymentType.CreditCard, CreditCardid = 4}
            };

            return paymentMethods;
        }
    }
}
