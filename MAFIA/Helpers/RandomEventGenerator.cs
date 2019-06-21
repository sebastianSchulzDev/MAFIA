using MAFIA.Classes;
using System.Collections.Generic;

namespace MAFIA.Helpers
{
    public static class RandomEventGenerator
    {
        public static RandomEventResult Generate(Gang gang)
        {
            var randomValue = RandomGenerator.GetForRange(0, 4);
            if (randomValue == 0)
            {
                var ev = _randomEvents[RandomGenerator.GetForRange(0, _randomEvents.Count)];
                if (ev.CanAffectGang(gang))
                    return new RandomEventResult(ev);
            }
            return new RandomEventResult();
        }

        private static List<RandomEvent> _randomEvents = new List<RandomEvent>
        {
            new RandomEvent("Napad przeciwnego gangu", true, false),
            new RandomEvent("Nalot policji", true, false),
            new RandomEvent("Tornado", false, true),
            new RandomEvent("Powódź", false, true),
            new RandomEvent("Wybuch bomby na naszym terenie", true, true),
            new RandomEvent("Samochód pułapka", true, true),
        };
    }
}
