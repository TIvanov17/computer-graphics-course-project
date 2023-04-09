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

        public static bool IsGroupShapesKeyCombinationClicked(KeyEventArgs e)
        {
            return e.Control == true && e.KeyCode == Keys.G && e.Shift == false;
        }

        public static bool IsUngroupShapesKeyCombinationClicked(KeyEventArgs e)
        {
            return e.Control == true && e.KeyCode == Keys.G && e.Shift == true;
        }
    }
}
