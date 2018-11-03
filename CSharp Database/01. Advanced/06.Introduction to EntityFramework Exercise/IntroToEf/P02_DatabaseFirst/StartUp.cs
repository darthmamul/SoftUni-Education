using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;

namespace P02_DatabaseFirst
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using (SoftUniContext context = new SoftUniContext())
            {
                var townToRemove = Console.ReadLine();

                var town = context.Towns
                    .Include(t => t.Addresses)
                    .SingleOrDefault(t => t.Name == townToRemove);

                var addressCount = 0;

                if (town != null)
                {
                    addressCount = town.Addresses.Count;

                    context.Employees
                        .Where(e => e.AddressId != null && town.Addresses.Any(a => a.AddressId == e.AddressId))
                        .ToList()
                        .ForEach(e => e.Address = null);

                    context.SaveChanges();

                    context.Addresses.RemoveRange(town.Addresses);
                    context.Towns.Remove(town);
                    context.SaveChanges();

                    Console.WriteLine($"{addressCount} address in {townToRemove} was deleted");
                }
            }
        }
    }
}