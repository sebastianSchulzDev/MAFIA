
using System;
using MAFIA.Classes;
using MAFIA.Enums;
using MAFIA.Helpers;
using MAFIA.Interfaces;

namespace MAFIA.Activities
{
    public class Auction : Activity, ILoggable, IRequiresStrength, ICanAddMember
    {
        public Auction(string name) : base(name)
        {
        }

        public int RequiredStrength => 201;

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("Trwa wykonanie");
            var income = RandomGenerator.GetForRange(1000, 5000);
            game.Gang.AddMoney(income);

            var increaseWantedLevelPosibility = RandomGenerator.GetForRange(100,500);

            if (game.Gang.GetGangStrength() < increaseWantedLevelPosibility)
            {
                Console.WriteLine($"Si�a gangu jest za ma�a, zdobywacie {income}$ ale wzr�s� poziom poszukiwa� !");
                game.Police.IncreaseWantedLevel();
                return new ActivityLog(income, WantedLevelChange.Increase);
            }
            Console.WriteLine($"Zdobywacie {income}$!");
            return new ActivityLog(income);
        }
    }
}