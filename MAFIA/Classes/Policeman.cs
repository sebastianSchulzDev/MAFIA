namespace MAFIA.Classes
{
    public class Policeman : Person
    {
        public Policeman(string name, int bribe, int maxWantedLevelCancellation) : base(name) // przykład dziedziczenia
        {
            Bribe = bribe;  // przykład enkapsulacji
            MaxWantedLevelCancellation = maxWantedLevelCancellation;
        }

        public int Bribe { get; private set; }
        public int MaxWantedLevelCancellation { get; private set; }
    }
}