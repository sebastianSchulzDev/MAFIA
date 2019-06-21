using System;
using System.Collections.Generic;
using System.Text;
using MAFIA.Activities;
using MAFIA.Classes;

namespace MAFIA.Menus
{
    public class PoliceMenu : Menu
    {
        public Dictionary<int, Activity> MenuActions { get; private set; }

        public PoliceMenu(Game game) : base(game)
        {
            Console.Clear();
            MenuActions = new Dictionary<int, Activity>();
            int index = 1;
            game.Police.Policemen.ForEach(p =>
            {
                MenuActions.Add(index, new BribePolice(p));
                index++;
            });
            MenuActions.Add(index, new BackToMain("Powrót do menu głównego"));
        }

        public override void Display()
        {
            Console.WriteLine("Korupcja (kontakty z Policją)");
            Console.WriteLine("------");
            Console.WriteLine($"Poziom ścigania gangu: {Game.Police.GangWantedLevel}");

            Console.WriteLine("Przekup policjanta aby obniżyć poziom ścigiania");
            foreach (var menuItem in MenuActions)
            {
                Console.WriteLine($"{menuItem.Key}. {menuItem.Value.Name}");
            }
        }

        public override Menu DoAction(int action)
        {
            if (MenuActions.TryGetValue(action, out Activity selected))
            {
                if (selected is BribePolice bribeActivity) // (selected is BribePolice bribeActivity) - przyklad pattern matchingu
                {
                    if (Game.Police.GangWantedLevel == 0)
                    {
                        Console.WriteLine("Gang nie posiada poziomu ścigania");
                        return this;
                    }
                    else if (Game.Police.GangWantedLevel > bribeActivity.Policeman.MaxWantedLevelCancellation)
                    {
                        Console.WriteLine($"{bribeActivity.Policeman.Name} jest na zbyt niskim stanowisku aby obniżyć nasz poziom ścigania");
                        return this;
                    }
                    else if (Game.Gang.Money < bribeActivity.Policeman.Bribe)
                    {
                        Console.WriteLine("Brak pieniędzy na łapówkę");
                        return this;
                    }
                }

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
