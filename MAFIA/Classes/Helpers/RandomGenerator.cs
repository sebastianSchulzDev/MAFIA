using System;

namespace MAFIA.Classes.Helpers
{
    public class RandomGenerator
    {
        private static Random _rnd = new Random(DateTime.Now.Millisecond);
        public static int GetForRange(int min, int max)
        {
            return _rnd.Next(min, max);
        }
    }
}