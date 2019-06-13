using System;
using System.Collections.Generic;

namespace MAFIA.Classes
{
    public class Game
    {
        private const int ActivityLimitPerDay = 5;
        public Game()
        {
            Gang = new Gang();
            Police = new Police();
            DailyActivities = new List<ActivityLog>();
        }

        public void AddActivityLog(ActivityLog log) => DailyActivities.Add(log);
        public int GetRemainingActivitesCount() => ActivityLimitPerDay - DailyActivities.Count;
        public bool CanExecuteAction() => GetRemainingActivitesCount() < ActivityLimitPerDay;
        public bool EndDay() => throw new NotImplementedException();

        public Gang Gang { get; private set; }
        public Police Police { get; private set; }
        public List<ActivityLog> DailyActivities { get; private set; }
    }
}