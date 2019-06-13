using System.Collections.Generic;

namespace MAFIA.Classes
{
    public class Gang
    {
        public Gang()
        {
            Members = new List<GangMember>();
            Money = 0;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public List<GangMember> Members { get; private set; }
        public int Money { get; private set; }
    }
}