namespace MAFIA.Classes
{
    public class Equipment
    {
        public Equipment (string name, int strength, int cost)
        {
            Name = name;
            Strength = strength;
            Cost = cost; 
        }

        public string Name { get; private set; }
        public int Strength { get; private set; }
        public int Cost { get; private set; }
    }
}