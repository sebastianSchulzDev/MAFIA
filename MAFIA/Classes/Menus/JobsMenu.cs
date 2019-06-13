using System;
using System.Collections.Generic;
using MAFIA.Classes.Activities;
using MAFIA.Classes.Interfaces;

namespace MAFIA.Classes.Menus
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
                if(job.Value is IRequiresStrength)
                {
                    var strengthJob = job.Value as IRequiresStrength;
                    if (strengthJob.RequiredStrength > gangStrength)
                        continue;
                }
                Console.WriteLine($"{job.Key}. {job.Value.Name}");
            }
        }

        public override Menu DoAction(int action)
        {
            Activity selected;
            if (Jobs.TryGetValue(action, out selected))
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