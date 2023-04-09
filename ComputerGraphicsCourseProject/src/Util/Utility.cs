using System;
using System.Windows.Forms;

namespace Draw.Util
{
    class Utility
    {
        private static readonly Random randomGenerator = new Random();

        private Utility(){}

        public static int GenerateRandomNumber(int minValue, int maxValue)
        {
            return randomGenerator.Next(minValue, maxValue);
        }
    }
}
