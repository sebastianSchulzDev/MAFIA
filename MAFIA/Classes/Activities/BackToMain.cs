using System;

namespace MAFIA.Classes.Activities
{
    public class BackToMain : Activity
    {
        public BackToMain(string name) : base(name)
        {
        }

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.WriteLine("Powrót do głownego menu");
            return new ActivityLog();
        }
    }
}