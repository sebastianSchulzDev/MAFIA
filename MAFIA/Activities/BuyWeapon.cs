using System;
using System.Collections.Generic;
using System.Text;
using MAFIA.Classes;
using MAFIA.Interfaces;

namespace MAFIA.Activities
{
    public class BuyWeapon : Activity, ILoggable
    {
        public Equipment Weapon { get; }

        public BuyWeapon(Equipment weapon) : base(weapon.Name)
        {
            Weapon = weapon;
        }

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine($"Zakup broni: {Weapon.Name}");
            game.Gang.SpendMoney(Weapon.Cost);
            Console.WriteLine($"Wydano {Weapon.Cost}$");
            game.Gang.AddWeapon(Weapon);
            return new ActivityLog(-Weapon.Cost);
        }
    }
}
