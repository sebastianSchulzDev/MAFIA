using System.Collections.Generic;

namespace MAFIA.Classes
{
    public class Police
    {
        public Police()
        {
            Policemen = new List<Policeman>()
            {
                new Policeman("James Kowalsky", 200, 1),
                new Policeman("Max Wood", 1000, 2),
                new Policeman("Billy Joe", 3000, 3),
                new Policeman("Dirty Harry", 5000, 4),
            };
            GangWantedLevel = 0;
        }
        public void IncreaseWantedLevel()
        {
            GangWantedLevel += 1;
        }

        public void LowerWantedLevel()
        {
            GangWantedLevel -= 1;
        }

        public List<Policeman> Policemen { get; private set; }
        public int GangWantedLevel { get; private set; }
    }
}