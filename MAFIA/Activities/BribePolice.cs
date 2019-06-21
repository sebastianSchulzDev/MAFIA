using MAFIA.Classes;
using MAFIA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAFIA.Activities
{
    public class BribePolice : Activity, ILoggable
    {
        public Policeman Policeman { get; }

        public BribePolice(Policeman policeman)
            : base($"{policeman.Name} - łapówka {policeman.Bribe}$ (Maks. poziom - {policeman.MaxWantedLevelCancellation}")
        {
            Policeman = policeman;
        }

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine($"Przekupiono policjanta {Policeman.Name}. Obniżono poziom ścigania");
            game.Police.LowerWantedLevel();
            game.Gang.SpendMoney(Policeman.Bribe);
            Console.WriteLine($"Wydano {Policeman.Bribe} na łapówkę");
            return new ActivityLog(-Policeman.Bribe, Enums.WantedLevelChange.Decrease);
        }
    }
}
