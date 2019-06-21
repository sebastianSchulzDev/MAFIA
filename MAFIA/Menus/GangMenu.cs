using System;
using MAFIA.Classes;

namespace MAFIA.Menus
{
    public class GangMenu : Menu
    {
        public GangMenu(Game game) : base(game)
        {
            Console.Clear();
        }

        public override void Display()
        {
            Console.WriteLine("Gang");
            Console.WriteLine("------");
            Console.WriteLine($"Siła gangu: {Game.Gang.GetGangStrength()}");
            Console.WriteLine($"Oszczędności: {Game.Gang.Money}$");
            Console.WriteLine($"Liczba członków gangu: {Game.Gang.Members.Count}");
            Console.WriteLine($"Ilość wyposażenia gangu: {Game.Gang.Equipment.Count}");

            Console.WriteLine($"Wciśnij 1 aby powrócić do menu");
        }

        public override Menu DoAction(int action)
        {
            return new MainMenu(Game);
        }
    }
}
