using System;

namespace MAFIA.Classes.Activities
{
    public abstract class Activity
    {
        public string Name { get; private set; }
        public Activity(string name)
        {
            Name = name;
        }
        public abstract void Execute(Game game);
    }
}