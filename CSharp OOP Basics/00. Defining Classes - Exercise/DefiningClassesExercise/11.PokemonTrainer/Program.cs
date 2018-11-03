using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var trainers = new List<Trainer>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Tournament"))
                {
                    break;
                }

                var trainerInfo = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var trainerName = trainerInfo[0];
                var pokemonName = trainerInfo[1];
                var pokemonElement = trainerInfo[2];
                var pokemonHealth = int.Parse(trainerInfo[3]);

                if (!trainers.Any(t => t.Name == trainerName))
                {
                    var trainer = new Trainer(trainerName);
                    trainers.Add(trainer);
                }

                var currentTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);

                if (!currentTrainer.Pokemons.Any(p => p.Name == pokemonName))
                {
                    var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                    currentTrainer.Pokemons.Add(pokemon);
                }
                else
                {
                    currentTrainer.Pokemons.FirstOrDefault(p => p.Name == pokemonName).Element = pokemonElement;
                    currentTrainer.Pokemons.FirstOrDefault(p => p.Name == pokemonName).Health += pokemonHealth;
                }
            }

            var element = Console.ReadLine();
            while (element != "End")
            {
                for (int i = 0; i < trainers.Count; i++)
                {
                    var currentTrainer = trainers[i];
                    if (currentTrainer.Pokemons.Any(p => p.Element.Equals(element)))
                    {
                        currentTrainer.Badges++;
                    }
                    else
                    {
                        currentTrainer.Pokemons.ForEach(p => p.Health -= 10);
                        for (int j = 0; j < currentTrainer.Pokemons.Count; j++)
                        {
                            if (currentTrainer.Pokemons[j].Health <= 0)
                            {
                                currentTrainer.Pokemons.RemoveAt(j);
                                j--;
                            }
                        }
                    }
                }

                element = Console.ReadLine();
            }

            trainers = trainers.OrderByDescending(t => t.Badges).ToList();

            foreach (var trainer in trainers)
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
