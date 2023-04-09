using System.Windows.Forms;

namespace Draw.src.Util
{
    class Commands
    {
        public static bool IsCreateGroupShapesCommandClicked(KeyEventArgs e)
        {
            return e.Control == true && e.KeyCode == Keys.G && e.Shift == false;
        }

        public static bool IsUngroupShapesCommandClicked(KeyEventArgs e)
        {
            return e.Control == true && e.KeyCode == Keys.G && e.Shift == true;
        }

        public static bool IsCopySelectedShapesCommandClicked(KeyEventArgs e)
        {
            return e.Control == true && e.KeyCode == Keys.C;
        }

        public static bool IsPasteSelectedShapesCommandClicked(KeyEventArgs e)
        {
            return e.Control == true && e.KeyCode == Keys.V;
        }
    }
}
