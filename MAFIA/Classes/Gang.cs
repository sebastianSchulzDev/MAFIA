using System.Collections.Generic;
using System.Linq;

namespace MAFIA.Classes
{
    public class Gang
    {
        public Gang()
        {
            Members = new List<GangMember>
            {
                new GangMember("John Doe", 30,10)
            };
            Money = 10;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public int GetGangStrength()
        {
            return Members.Sum(member => member.Strength);
        }

        public List<GangMember> Members { get; private set; }
        public int Money { get; private set; }


    }
}