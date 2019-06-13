using System;
using System.Collections.Generic;
using MAFIA.Classes.Activities;

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
                { 2, new Extortion("Haracz2") },
            };
        }

        public override void Display()
        {
            Console.WriteLine("Roboty");
            Console.WriteLine("------");
            foreach (var job in Jobs)
            {
                Console.WriteLine($"{job.Key}. {job.Value.Name}");
            }
        }
    }
}