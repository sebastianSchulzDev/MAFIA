namespace MAFIA.Classes.Menus
{
    public abstract class Menu
    {
        public Menu(Game game)
        {
            Game = game;
        }
        public Game Game { get; private set; }

        public abstract void Display();

        public abstract void DoAction(int action);
    }
}