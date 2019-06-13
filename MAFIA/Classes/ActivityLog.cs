namespace MAFIA.Classes
{
    public class ActivityLog
    {
        public ActivityLog() { }
        public ActivityLog(int income)
        {
            Income = income;
        }
        public int Income { get; private set; }
    }
}