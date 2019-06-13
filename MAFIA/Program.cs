using System;
using MAFIA.Classes;
using MAFIA.Classes.Menus;

namespace MAFIA
{
    class Program
    {
        static Game _game = new Game();

        static void Main(string[] args)
        {
            Menu activeMenu = new MainMenu(_game);
            while (true)
            {
                try
                {
                    activeMenu.Display();
                    var action = GetSelectedAction();
                    if (action == 0) continue;

                    activeMenu = activeMenu.DoAction(action);
                }
                catch
                {
                    Console.WriteLine("Wystąpił nieoczekiwany błąd");
                }
            }
        }

        private static int GetSelectedAction()
        {
            int action = 0;
            var input = Console.ReadLine();
            if (Int32.TryParse(input, out action))
                return action;

            Console.WriteLine("Nieprawidłowa wartość");
            return 0;
        }
    }
}
