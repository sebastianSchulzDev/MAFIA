namespace MAFIA.Classes
{
    public class Infrastructure
    {
        public Infrastructure(string name, int cost, int income)
        {
            Name = name;
            Cost = cost;
            Income = income;
        }

        public string Name { get; }
        public int Cost { get; }
        public int Income { get; }
    }
}