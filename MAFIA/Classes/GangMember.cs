namespace MAFIA.Classes
{
    public class GangMember : Person
    {
        public GangMember(string name) : base(name)
        {

        }
        public int Strength { get; set; }
        public int Money { get; set; }

    }
}