using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Smartphone : IBrowsable, ICallable
{
    public string Browse(string website)
    {
        if (website.Any(w => char.IsDigit(w)))
        {
            return "Invalid URL!";
        }

        return $"Browsing: {website}!";
    }

    public string Call(string phoneNumber)
    {
        if (phoneNumber.Any(p => !char.IsDigit(p)))
        {
            return "Invalid number!";
        }

        return $"Calling... {phoneNumber}";
    }
}

