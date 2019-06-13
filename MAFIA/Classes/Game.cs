namespace MAFIA.Classes
{
    public class Game
    {
        public Game()
        {
            Gang = new Gang();
            Police = new Police();
        }
        public Gang Gang { get; set; }
        public Police Police { get; set; }
    }
}