using MAFIA.Classes;
using MAFIA.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MAFIA.Activities
{
    public class BuyInfrastructure : Activity, ILoggable
    {
        public Infrastructure Property { get; }

        public BuyInfrastructure(Infrastructure property) : base(property.Name)
        {
            Property = property;
        }

        protected override ActivityLog ExecuteActivity(Game game)
        {
            Console.Clear();
            Console.WriteLine($"Zakup nieruchomości: {Property.Name}");
            game.Gang.SpendMoney(Property.Cost);
            Console.WriteLine($"Wydano {Property.Cost}$");
            game.Gang.AddProperty(Property);
            return new ActivityLog(-Property.Cost);
        }
    }
}
