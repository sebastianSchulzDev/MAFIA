using System;
using System.Collections.Generic;
using MAFIA.Activities;
using MAFIA.Classes;

namespace MAFIA.Menus
{
    public class WeaponsMenu : Menu
    {
        public Dictionary<int, Activity> Weapons { get; private set; }

        public WeaponsMenu(Game game) : base(game)
        {
            Console.Clear();
            Weapons = new Dictionary<int, Activity>
            {
                { 1, new BuyWeapon(new Equipment("Nóż", 5, 10)) },
                { 2, new BuyWeapon(new Equipment("Pistolet", 15, 30)) },
                { 3, new BackToMain("Powrót do menu głównego") },
            };
        }

        public override void Display()
        {
            Console.WriteLine("Bronie");
            Console.WriteLine("------");
            var gangStrength = Game.Gang.GetGangStrength();
            foreach (var weapon in Weapons)
            {
                Console.WriteLine($"{weapon.Key}. {weapon.Value.Name}");
            }
        }

        public override Menu DoAction(int action)
        {
            if (Weapons.TryGetValue(action, out Activity selected))
            {
                if (selected is BuyWeapon butActivity && Game.Gang.Money < butActivity.Weapon.Cost) // (selected is BuyWeapon buyAction) - przyklad pattern matchingu
                {
                    Console.WriteLine("Brak środków do zakupu broni");
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
