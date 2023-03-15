using System;

namespace Draw.Util
{
    class Utility
    {
        private static Random randomGenerator = new Random();

        private Utility()
        {

        }

        public static Random GetRandomGenerator()
        {
            if(randomGenerator == null)
            {
                return new Random();
            }

            return randomGenerator;
        }

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return randomGenerator.Next(minValue, maxValue);
        }
    }
}
