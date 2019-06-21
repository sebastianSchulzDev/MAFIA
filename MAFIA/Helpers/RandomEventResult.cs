using MAFIA.Classes;

namespace MAFIA.Helpers
{
    public class RandomEventResult
    {
        public RandomEventResult()
        {
            EventOccured = false;
        }

        public RandomEventResult(RandomEvent randomEvent)
        {
            EventOccured = true;
            RandomEvent = randomEvent;
        }

        public bool EventOccured { get; }
        public RandomEvent RandomEvent { get; }
    }
}
