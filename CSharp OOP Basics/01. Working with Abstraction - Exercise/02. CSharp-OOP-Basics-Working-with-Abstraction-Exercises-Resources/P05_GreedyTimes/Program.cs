using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_GreedyTimes
{

    public class Potato
    {
        static void Main(string[] args)
        {
            long bagLimit = long.Parse(Console.ReadLine());
            string[] valueTokens = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var bag = new Dictionary<string, Dictionary<string, long>>();
            long gold = 0;
            long gems = 0;
            long cash = 0;

            for (int i = 0; i < valueTokens.Length; i += 2)
            {
                string value = valueTokens[i];
                long amount = long.Parse(valueTokens[i + 1]);

                string valueType = string.Empty;

                if (value.Length == 3)
                {
                    valueType = "Cash";
                }
                else if (value.ToLower().EndsWith("gem"))
                {
                    valueType = "Gem";
                }
                else if (value.ToLower() == "gold")
                {
                    valueType = "Gold";
                }
                bool reachedBagSize = bagLimit < bag.Values.Select(x => x.Values.Sum()).Sum() + amount;

                if (valueType == string.Empty || reachedBagSize)
                {
                    continue;
                }

                switch (valueType)
                {
                    case "Gem":
                        if (!bag.ContainsKey(valueType))
                        {
                            if (bag.ContainsKey("Gold"))
                            {
                                if (amount > bag["Gold"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (IsBagLarger("Gold", bag, valueType, amount))
                        {
                            continue;
                        }
                        break;
                    case "Cash":
                        if (!bag.ContainsKey(valueType))
                        {
                            if (bag.ContainsKey("Gem"))
                            {
                                if (amount > bag["Gem"].Values.Sum())
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (IsBagLarger("Gem", bag, valueType, amount))
                        {
                            continue;
                        }
                        break;
                }

                if (!bag.ContainsKey(valueType))
                {
                    bag[valueType] = new Dictionary<string, long>();
                }

                if (!bag[valueType].ContainsKey(value))
                {
                    bag[valueType][value] = 0;
                }

                bag[valueType][value] += amount;
                if (valueType == "Gold")
                {
                    gold = AddQuantity(gold, amount);
                }
                else if (valueType == "Gem")
                {
                    gems = AddQuantity(gems, amount);
                }
                else if (valueType == "Cash")
                {
                    cash = AddQuantity(cash, amount);
                }
            }

            foreach (var x in bag)
            {
                Console.WriteLine($"<{x.Key}> ${x.Value.Values.Sum()}");
                foreach (var item2 in x.Value.OrderByDescending(y => y.Key).ThenBy(y => y.Value))
                {
                    Console.WriteLine($"##{item2.Key} - {item2.Value}");
                }
            }
        }

        private static bool IsBagLarger(string value, Dictionary<string, Dictionary<string, long>> bag, string valueType, long amount)
        {
            return bag[valueType].Values.Sum() + amount > bag[value].Values.Sum();
        }

        static long AddQuantity(long value, long quantity)
        {
            return value += quantity;
        }
    }
}