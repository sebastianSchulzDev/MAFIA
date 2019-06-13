
using System;
using MAFIA.Classes.Helpers;
using MAFIA.Classes.Interfaces;

namespace MAFIA.Classes.Activities
{
    public class Heist : Activity, ILoggable
    {
        public Heist(string name) : base(name)
        {
        }

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("Trwa wykonanie");
            var income = RandomGenerator.GetForRange(100, 3500);

            if (game.Gang.GetGangStrength() <= 20)
            {
                Console.WriteLine($"Si³a gangu jest za ma³a, tracicie {income}$ !");
                game.Gang.AddMoney(income * (-1));
                return new ActivityLog(income *(-1));
            }
            else
            {
                Console.WriteLine($"Zdoby³eœ {income}$ !");
                game.Gang.AddMoney(income);
                return new ActivityLog(income);
            }
               
        }
    }
}