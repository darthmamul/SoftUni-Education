using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();
            var products = new List<Product>();

            var personAndTheirMoney = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var currentPerson in personAndTheirMoney)
            {
                try
                {
                    var currentPersonTokens = currentPerson.Split('=');
                    var name = currentPersonTokens[0];
                    var money = decimal.Parse(currentPersonTokens[1]);
                    var person = new Person(name, money);
                    people.Add(person);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var productAndTheirCost = Console.ReadLine().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var currentProduct in productAndTheirCost)
            {
                try
                {
                    var currentProductTokens = currentProduct.Split('=');
                    var productName = currentProductTokens[0];
                    var cost = decimal.Parse(currentProductTokens[1]);
                    var product = new Product(productName, cost);
                    products.Add(product);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }

            var commandLine = Console.ReadLine();
            while (!commandLine.Equals("END"))
            {
                var tokens = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var person = people.FirstOrDefault(x => x.Name == tokens[0]);
                var product = products.FirstOrDefault(x => x.Name == tokens[1]);

                if (person != null && product != null)
                {
                    if (product.Cost <= person.Money)
                    {
                        person.Products.Add(product);
                        person.Money -= product.Cost;

                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }

                commandLine = Console.ReadLine();
            }

            foreach (var person in people)
            {
                if (!person.Products.Any())
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                    continue;
                }

                Console.WriteLine($"{person.Name} - {string.Join(", ", person.Products)}");
            }
        }
    }
}
