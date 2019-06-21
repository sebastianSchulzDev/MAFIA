using System.Linq;

namespace MAFIA.Classes
{
    public class RandomEvent
    {
        public RandomEvent(string name, bool affectsMembers, bool affectsInfrastructure)
        {
            Name = name;
            AffectsMembers = affectsMembers;
            AffectsInfrastructure = affectsInfrastructure;
        }

        public bool CanAffectGang(Gang gang)
        {
            return (AffectsMembers && gang.Members.Count > 1) ||
                (AffectsInfrastructure && gang.Properties.Any());
        }

        public string Name { get; }
        public bool AffectsMembers { get; }
        public bool AffectsInfrastructure { get; }
    }
}
