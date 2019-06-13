using System.Collections.Generic;

namespace MAFIA.Classes
{
    public class Police
    {
        public Police()
        {
            Policemen = new List<Policeman>();
            GangWantedLevel = 0;
        }
        public void IncreaseWantedLevel()
        {
            GangWantedLevel += 1;
        }
        public List<Policeman> Policemen { get; private set; }
        public int GangWantedLevel { get; private set; }
    }
}