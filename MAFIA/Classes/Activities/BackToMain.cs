using System;

namespace MAFIA.Classes.Activities
{
    public class BackToMain : Activity
    {
        public BackToMain(string name) : base(name)
        {
        }

        public override void Execute(Game game)
        {
            Console.WriteLine("Powrót do głownego menu");
        }
    }
}