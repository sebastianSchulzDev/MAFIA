using System;
using MAFIA.Classes.Menus;

namespace MAFIA
{
    class Program
    {
        static void Main(string[] args)
        {
            new JobsMenu(new Classes.Game()).Display();
            Console.ReadLine();
        }
    }
}
