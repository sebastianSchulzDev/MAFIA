using System.Collections.Generic;
using System.Linq;

namespace MAFIA.Classes
{
    public class Gang
    {
        public Gang()
        {
            _members = new List<GangMember>
            {
                new GangMember("John Doe", 30, 10)
            };
            _equipment = new List<Equipment>();
            _properties = new List<Infrastructure>();
            Money = 10;
            NumberOfDistricts = 0;
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
            _equipment.Add(weapon);
        }

        public void AddProperty(Infrastructure property)
        {
            _properties.Add(property);
        }

        public void RemoveProperty(Infrastructure property)
        {
            _properties.Remove(property);
        }

        public void AddMember(GangMember member)
        {
            _members.Add(member);
            AddMoney(member.Money);
        }

        public void RemoveMember(GangMember member)
        {
            _members.Remove(member);
        }

        public void RemoveAllMembers()
        {
            _members.Clear();
        }

        public int GetGangStrength()
        {
            return Members.Sum(member => member.Strength) + Equipment.Sum(eq => eq.Strength);
        }

        public void AddDistrict()
        {
            NumberOfDistricts += 1;
        }

        public int GetDailyIncome() => Properties.Sum(p => p.Income);

        private readonly List<GangMember> _members; // Enkapsulacja listy cz³onków
        public IReadOnlyList<GangMember> Members => _members;

        private readonly List<Equipment> _equipment;
        public IReadOnlyList<Equipment> Equipment => _equipment;

        private readonly List<Infrastructure> _properties;
        public IReadOnlyList<Infrastructure> Properties => _properties;

        public int Money { get; private set; }
        public int NumberOfDistricts { get; private set; }
    }
}