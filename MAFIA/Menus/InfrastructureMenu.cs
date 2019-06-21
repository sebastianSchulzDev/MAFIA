using System;
using System.Collections.Generic;
using System.Text;
using MAFIA.Activities;
using MAFIA.Classes;

namespace MAFIA.Menus
{
    public class InfrastructureMenu : Menu
    {
        public Dictionary<int, Activity> MenuItems { get; private set; }

        public InfrastructureMenu(Game game) : base(game)
        {
            Console.Clear();
            MenuItems = new Dictionary<int, Activity>
            {
                { 1, new BuyInfrastructure(new Infrastructure("Stragan", 500, 100)) },
                { 2, new BuyInfrastructure(new Infrastructure("Kiosk", 2500, 500)) },
                { 3, new BuyInfrastructure(new Infrastructure("Żabka", 10000, 1000)) },
                { 4, new BuyInfrastructure(new Infrastructure("Biedronka", 100000, 3000)) },
                { 5, new BuyInfrastructure(new Infrastructure("Kasyno", 500000, 5000)) },
                { 6, new BuyInfrastructure(new Infrastructure("Hotel", 1000000, 10000)) },
                { 7, new BackToMain("Powrót do menu głównego") },
            };
        }

        public override void Display()
        {
            Console.WriteLine("Infrastruktura");
            Console.WriteLine("------");
            foreach (var menuItem in  MenuItems)
            {
                Console.WriteLine($"{menuItem.Key}. {menuItem.Value.Name}");
            }
        }

        public override Menu DoAction(int action)
        {
            if (MenuItems.TryGetValue(action, out Activity selected))
            {
                if (selected is BuyInfrastructure buyActivity && Game.Gang.Money < buyActivity.Property.Cost)
                {
                    Console.Clear();
                    Console.WriteLine("Brak środków do zakupu nieruchomości");
                    return this;
                }
                else
                {
                    selected.Execute(Game);
                    return new MainMenu(Game);
                }
            }
            else
            {
                Console.WriteLine("Nieprawidłowa akcja");
                return this;
            }
        }
    }
}
