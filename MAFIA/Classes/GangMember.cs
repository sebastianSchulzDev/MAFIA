namespace MAFIA.Classes
{
    public class GangMember : Person
    {
        public GangMember(string name, int strength, int money) : base(name)
        {
            Strength = strength;
            Money = money;
        }
        public int Strength { get; set; }
        public int Money { get; set; }

    }
}