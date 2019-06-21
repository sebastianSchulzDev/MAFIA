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
            Equipment = new List<Equipment>();
            Money = 10;
        }

        public void AddMoney(int amount)
        {
            Money += amount;
        }

        public void SpendMoney(int amount)
        {
            Money -= amount;
        }

        public void AddWeapon(Equipment weapon)
        {
            Equipment.Add(weapon);
        }

        public int GetGangStrength()
        {
            return Members.Sum(member => member.Strength);
        }

        public List<GangMember> Members { get; private set; }
        public List<Equipment> Equipment { get; private set; }
        public int Money { get; private set; }


    }
}