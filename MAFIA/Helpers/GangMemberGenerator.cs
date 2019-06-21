using MAFIA.Classes;
using System.Collections.Generic;

namespace MAFIA.Helpers
{
    public static class GangMemberGenerator
    {
        public static GangMember CreateRandomMember()
        {
            var strength = RandomGenerator.GetForRange(10, 100);
            var money = RandomGenerator.GetForRange(10, 100);
            return new GangMember(GetRandomName(), strength, money);
        }

        private static string GetRandomName()
        {
            var firstNameIndex = RandomGenerator.GetForRange(0, FirstNames.Count);
            var lastNameIndex = RandomGenerator.GetForRange(0, LastNames.Count);

            return $"{FirstNames[firstNameIndex]} {LastNames[lastNameIndex]}";
        }

        private static List<string> FirstNames = new List<string> { "John", "Nathan", "Ash" };
        private static List<string> LastNames = new List<string> { "Drake", "Wick", "Ketchum" };
    }
}
