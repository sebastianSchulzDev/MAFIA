using MAFIA.Classes;
using System;
using System.Collections.Generic;

namespace MAFIA.Menus
{
    public class MainMenu : Menu
    {
        public MainMenu(Game game) : base(game)
        {
        }

        public override void Display()
        {
            Console.WriteLine("------");
            Console.WriteLine("MENU");
            Console.WriteLine("------");
            Console.WriteLine($"Pozostało akcji do wykonania: {Game.GetRemainingActivitesCount()}");
            Console.WriteLine("------");
            if (Game.CanExecuteAction())
            {
                Console.WriteLine("1.Roboty");
                Console.WriteLine("2.Gang");
                Console.WriteLine("3.Ekwipunek");
                Console.WriteLine("4.Infrastruktura");
                Console.WriteLine("5.Korupcja (kontakty z Policją)");
            }

            Console.WriteLine("7.Zakończ dzień");

            Console.WriteLine("8.Zakończ grę.");
        }

        public List<int> DailLimitedActions = new List<int> { 1, 2, 3, 4, 5 };

        public override Menu DoAction(int action)
        {
            if(IsActionLimited(action))
            {
                Console.Clear();
                Console.WriteLine("Wybrana akcja jest niedostępna. Osiągnięto dzienny limit akcji.");
                return this;
            }
            switch (action)
            {
                case 1:
                    return new JobsMenu(Game);
                case 2:
                    return new GangMenu(Game);
                case 3:
                    return new WeaponsMenu(Game);
                case 4:
                    return new InfrastructureMenu(Game);
                case 5:
                    return new PoliceMenu(Game);
                default:
                    Console.Clear();
                    Console.WriteLine("Nieprawidłowa akcja");
                    return this;
            }
        }

        private bool IsActionLimited(int action)
        {
            return !Game.CanExecuteAction() && DailLimitedActions.Contains(action);
        }
    }
}