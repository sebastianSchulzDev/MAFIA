using System;
using System.Collections.Generic;
using MAFIA.Activities;
using MAFIA.Classes;
using MAFIA.Interfaces;

namespace MAFIA.Menus
{
    public class JobsMenu : Menu
    {
        public Dictionary<int, Activity> Jobs { get; private set; }
        public JobsMenu(Game game) : base(game)
        {
            Jobs = new Dictionary<int, Activity>
            {
                { 1, new Extortion("Haracz") },
                { 2, new Heist("Napad") },
                { 3, new Robbery("Rozbój") },
                { 4, new Trade("Handel") },
                { 5, new Auction("Przetarg") },
                { 7, new BackToMain("Powrót do menu głównego") },
            };
        }

        public override void Display()
        {
            Console.WriteLine("Roboty");
            Console.WriteLine("------");
            var gangStrength = Game.Gang.GetGangStrength();
            foreach (var job in Jobs)
            {
                if (!HasRequiredStrength(gangStrength, job.Value))
                    continue;
                Console.WriteLine($"{job.Key}. {job.Value.Name}");
            }
        }

        private bool HasRequiredStrength(int gangStrength, Activity job)
        {
            if (job is IRequiresStrength)
            {
                var strengthJob = job as IRequiresStrength;
                if (strengthJob.RequiredStrength > gangStrength)
                    return false;
            }
            return true;
        }

        public override Menu DoAction(int action)
        {
            if (Jobs.TryGetValue(action, out Activity selected))
            {
                selected.Execute(Game);
                return new MainMenu(Game);
            }
            else
            {
                Console.WriteLine("Nieprawidłowa akcja");
                return this;
            }
        }
    }
}