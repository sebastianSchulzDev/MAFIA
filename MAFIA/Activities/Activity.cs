using System;
using MAFIA.Classes;
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
            if (this is ILoggable)
                game.AddActivityLog(log);
        }
    }
}