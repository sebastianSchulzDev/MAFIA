using System;
using MAFIA.Classes.Helpers;
using MAFIA.Classes.Interfaces;

namespace MAFIA.Classes.Activities
{
    public class Extortion : Activity, ILoggable
    {
        public Extortion(string name) : base(name)
        {
        }

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("Ściąganie haraczu...");
            var income = RandomGenerator.GetForRange(1, 100);
            game.Gang.AddMoney(income);

            if (income == 0)
                Console.WriteLine("Fail");
            else
                Console.WriteLine($"Zdobyłeś {income}$ haraczu!");

            return new ActivityLog(income);
        }
    }
}