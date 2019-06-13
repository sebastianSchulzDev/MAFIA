namespace MAFIA.Classes
{
    public class Policeman : Person
    {
        public Policeman(string name, int bribe) : base(name) // przykład dziedziczenia
        {
            Bribe = bribe;  // przykład enkapsulacji
        }

        public int Bribe { get; private set; }
    }
}