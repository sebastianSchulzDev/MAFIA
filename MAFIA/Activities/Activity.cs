using System;
using MAFIA.Classes;
using MAFIA.Helpers;
using MAFIA.Interfaces;

namespace MAFIA.Activities
{
    public abstract class Activity
    {
        public string Name { get; private set; }
        public Activity(string name)
        {
            Name = name;
        }
        protected abstract ActivityLog ExecuteActivity(Game game);

        public virtual void Execute(Game game)
        {
            var log = ExecuteActivity(game);
            if (this is ICanAddMember)
            {
                var memberAdded = RandomGenerator.GetForRange(0, 2);
                if (memberAdded == 1)
                {
                    var newMember = GangMemberGenerator.CreateRandomMember();
                    Console.WriteLine($"Podczas akcji przy��czy� si� nowy cz�onek gangu, {newMember.Name} " +
                        $"(si�a: {newMember.Strength}, pieni�dze: {newMember.Money}$)");
                    game.Gang.AddMember(newMember);
                }
            }
            if (this is ILoggable)
                game.AddActivityLog(log);
        }
    }
}