using System;
using MAFIA.Classes.Helpers;

namespace MAFIA.Classes.Activities
{
    public class Extortion : Activity
    {
        public Extortion(string name) : base(name)
        {
        }

        public override void Execute(Game game)
        {
            Console.WriteLine(Name);
            Console.WriteLine("Ściąganie haraczu...");
            var income = RandomGenerator.GetForRange(1, 100);
            game.Gang.AddMoney(income);

            if (income == 0)
                Console.WriteLine("Fail");
            else
                Console.WriteLine($"Zdobyłeś {income}$ haraczu!");
        }
    }
}