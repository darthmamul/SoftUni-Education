using P01_BillsPaymentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Initializer
{
    internal class UserInitializer
    {
        internal static User[] GetUsers()
        {
            User[] users = new User[]
            {
                new User(){FirstName = "Pesho", LastName = "Peshov", Email = "pesho@abv.bg", Password = "peshkat1"},
                new User(){FirstName = "Dobri", LastName = "Dobrev", Email = "dobrqka@gmail.com", Password = "dob4eto"},
                new User(){FirstName = "Gogo", LastName = "Tankov", Email = "tonika@mail.bg", Password = "dance4me"},
                new User(){FirstName = "Pecata", LastName = "Lekarov", Email = "penicilina@abv.bg", Password = "pecn1q"},
                new User(){FirstName = "Kiril", LastName = "Donev", Email = "nedomus@yahoo.com", Password = "bmfto12"},
            };

            return users;
        }
    }
}
