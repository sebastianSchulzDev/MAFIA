
using System;
using MAFIA.Classes;
using MAFIA.Enums;
using MAFIA.Helpers;
using MAFIA.Interfaces;

namespace MAFIA.Activities
{
    public class Robbery : Activity, ILoggable, IRequiresStrength, ICanAddMember
    {
        public Robbery(string name) : base(name)
        {
        }

        public int RequiredStrength => 41;

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine(Name);
            Console.WriteLine("Trwa wykonanie");
            var income = RandomGenerator.GetForRange(300, 600);
            game.Gang.AddMoney(income);

            var increaseWantedLevelPosibility = RandomGenerator.GetForRange(50, 200);

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