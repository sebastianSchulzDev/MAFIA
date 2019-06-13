using System.Collections.Generic;

namespace MAFIA.Classes
{
    public class Police
    {
        public Police()
        {
            Policemen = new List<Policeman>();
        }
        public List<Policeman> Policemen { get; private set; }
    }
}