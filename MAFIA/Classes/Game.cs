using System;
using System.Collections.Generic;

namespace MAFIA.Classes
{
    public class Game
    {
        public const int ActivityLimitPerDay = 5;
        public const int DistrictsCount = 13;

        public Game()
        {
            Gang = new Gang();
            Police = new Police();
            DailyActivities = new List<ActivityLog>();
            Day = 1;
        }

        public void AddActivityLog(ActivityLog log) => DailyActivities.Add(log);
        public int GetRemainingActivitesCount() => ActivityLimitPerDay - DailyActivities.Count;
        public bool CanExecuteAction() => GetRemainingActivitesCount() > 0;
        public void EndDay()
        {
            DailyActivities.Clear();
            Day += 1;
        }

        public Gang Gang { get; private set; }
        public Police Police { get; private set; }
        public List<ActivityLog> DailyActivities { get; private set; }
        public int Day { get; private set; }
    }
}