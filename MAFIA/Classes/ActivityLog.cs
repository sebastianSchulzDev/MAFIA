using System;
using MAFIA.Classes.Enums;

namespace MAFIA.Classes
{
    public class ActivityLog
    {
        public ActivityLog() { }
        public ActivityLog(int income, WantedLevelChange wantedLevelChange = Enums.WantedLevelChange.NoChange)
        {
            Income = income;
            CheckWantedLevelChange(wantedLevelChange);
        }

        private void CheckWantedLevelChange(WantedLevelChange wantedLevelChange)
        {
            switch (wantedLevelChange)
            {
                case Enums.WantedLevelChange.Increase:
                    WantedLevelChange += 1;
                    break;
                case Enums.WantedLevelChange.Decrease:
                    WantedLevelChange -= 1;
                    break;
                default:
                    break;
            }
        }

        public int Income { get; private set; }
        public int WantedLevelChange { get; private set; }
    }
}