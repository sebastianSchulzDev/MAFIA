
using System;
using MAFIA.Classes;
using MAFIA.Enums;
using MAFIA.Helpers;
using MAFIA.Interfaces;

namespace MAFIA.Activities
{
    public class Heist : Activity, ILoggable, IRequiresStrength, ICanAddMember
    {
        public Heist(string name) : base(name)
        {
        }

        public int RequiredStrength => 21;

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("Trwa wykonanie");
            var income = RandomGenerator.GetForRange(100, 200);
            game.Gang.AddMoney(income);

            var increaseWantedLevelPosibility = RandomGenerator.GetForRange(0, 50);

            if (game.Gang.GetGangStrength() < increaseWantedLevelPosibility)
            {
                Console.WriteLine($"Si³a gangu jest za ma³a, zdobywacie {income}$ ale wzrós³ poziom poszukiwañ !");
                game.Police.IncreaseWantedLevel();
                return new ActivityLog(income, WantedLevelChange.Increase);
            }
            Console.WriteLine($"Zdobywacie {income}$!");
            return new ActivityLog(income);
        }
    }
}