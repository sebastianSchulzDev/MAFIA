using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MAFIA.Classes;
using MAFIA.Helpers;

namespace MAFIA.Menus
{
    public class DailySummaryMenu : Menu
    {
        public DailySummaryMenu(Game game) : base(game)
        {
        }

        public bool GameHasEnded { get; private set; }

        public override void Display()
        {
            Console.Clear();
            Console.WriteLine("======");
            Console.WriteLine("Podsumowanie dnia");
            Console.WriteLine("======");

            CheckRandomEventOccurance();
            if (HasGameEnded())
            {
                GameHasEnded = true;
                Console.WriteLine("======");
                Console.WriteLine("Możliwe akcje");
                Console.WriteLine("======");
                Console.WriteLine("1.Zrestartuj grę");
                Console.WriteLine("2.Zamknij grę");
            }
            else
            {
                ShowDailySummary();
                Console.WriteLine("======");
                Console.WriteLine("Możliwe akcje");
                Console.WriteLine("======");
                Console.WriteLine("1.Przejdź do kolejnego dnia");
                Console.WriteLine("2.Zamknij grę");
            }
        }

        private void ShowDailySummary()
        {
            if (!Game.DailyActivities.Any())
            {
                Console.WriteLine("Brak aktywności w minionym dniu");
            }
            else
            {
                var income = Game.DailyActivities.Sum(a => a.Income);
                var propertyIncome = Game.Gang.Properties.Sum(p => p.Income);
                if(propertyIncome > 0)
                {
                    Console.WriteLine($"Dochód z nieruchomości: {propertyIncome}$");
                    Game.Gang.AddMoney(propertyIncome);
                    income += propertyIncome;
                }
                Console.WriteLine($"Łączny dzienny balans: {income}$");
                var wantedLevelChange = Game.DailyActivities.Sum(a => a.WantedLevelChange);
                if (wantedLevelChange > 0)
                    Console.WriteLine($"Poziom ścigania przez policję wzrósł o {wantedLevelChange}.");
                else if (wantedLevelChange < 0)
                    Console.WriteLine($"Poziom ścigania przez policję zmalał o {-wantedLevelChange}.");
            }
            Game.EndDay();
        }

        private bool HasGameEnded()
        {
            if (Game.Police.GangWantedLevel > Police.MaxWantedLevel)
            {
                var gang = Game.Gang;
                Console.WriteLine("Koniec gry. Osiągnięto maksymalny poziom ścigania policji i Twój gang został rozbity ale Tobie udało się uciec!");
                if (gang.Members.Any())
                    Console.WriteLine($"Liczba zatrzymanych osób: {gang.Members.Count}");
                if (gang.Properties.Any())
                    Console.WriteLine($"Ilość przejętych nieruchomości: {gang.Properties.Count}");
                if (gang.Money > 0)
                    Console.WriteLine($"Zabezpieczono {gang.Money}$ w gotówce");
                if (gang.Equipment.Any())
                    Console.WriteLine($"Zarekwirowano broń w ilości: {gang.Equipment.Count}");

                return true;
            }
            else if (Game.Gang.NumberOfDistricts >= Game.DistrictsCount)
            {
                Console.WriteLine("Udało Ci się przejąć władzę nad całym miastem. Koniec gry!");
                Console.WriteLine("Odblokowałeś trofeum: 'To miasto jest Twoje!'");

                return true;
            }
            return false;
        }

        private void CheckRandomEventOccurance()
        {
            var @event = RandomEventGenerator.Generate(Game.Gang);
            if (!@event.EventOccured)
                return;
            Console.WriteLine("Nastąpiło zdarzenie losowe.");
            Console.WriteLine(@event.RandomEvent.Name);
            if (@event.RandomEvent.AffectsMembers)
            {
                var numberOfCasualities = RandomGenerator.GetForRange(1, 4);
                if (numberOfCasualities >= Game.Gang.Members.Count)
                {
                    Console.WriteLine("W wyniku zdarzenia losowego straciliśmy wszystkich członków gangu");
                    Game.Gang.RemoveAllMembers();
                }
                else
                {
                    Console.WriteLine($"W wyniku zdarzenia straciliśmy następującą ilość członków gangu: {numberOfCasualities}");
                    while (numberOfCasualities > 0)
                    {
                        var lostMember = Game.Gang.Members[RandomGenerator.GetForRange(0, Game.Gang.Members.Count)];
                        Game.Gang.RemoveMember(lostMember);
                        numberOfCasualities--;
                    }
                }
            }
            if (@event.RandomEvent.AffectsInfrastructure)
            {
                var destroyedProperty = Game.Gang.Properties[RandomGenerator.GetForRange(0, Game.Gang.Properties.Count)];
                Console.WriteLine($"W wyniku zdarzenia losowego straciliśmy nieruchomość: {destroyedProperty.Name}.");
                Game.Gang.RemoveProperty(destroyedProperty);
            }
        }

        public override Menu DoAction(int action)
        {
            Console.Clear();
            if (action == 2)
            {
                Environment.Exit(-1);
            }

            if (GameHasEnded)
            {
                return new MainMenu(new Game());
            }
            else
            {
                return new MainMenu(Game);
            }
        }
    }
}
