using System;

namespace MAFIA.Classes.Menus
{
    public class MainMenu : Menu
    {
        public MainMenu(Game game) : base(game)
        {
        }

        public override void Display()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("------");
            Console.WriteLine("1.Roboty");
            Console.WriteLine("2.Gang");
            Console.WriteLine("3.Ekwipunek");
            Console.WriteLine("4.Infrastruktura");
            Console.WriteLine("5.Korupcja (kontakty z Policją)");
            Console.WriteLine("6.Poziom ścigania");
            Console.WriteLine("7.Zakończ grę.");
        }

        public override void DoAction(int action)
        {
            throw new NotImplementedException();
        }
    }
}