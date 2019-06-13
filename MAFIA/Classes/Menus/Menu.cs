namespace MAFIA.Classes.Menus
{
    public abstract class Menu
    {
        protected Game Game { get; private set; }
        public Menu(Game game)
        {
            Game = game;
        }

        public abstract void Display();

        public abstract Menu DoAction(int action);
    }
}