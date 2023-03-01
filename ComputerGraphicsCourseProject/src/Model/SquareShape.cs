using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    class SquareShape : RectangleShape
    {

        public SquareShape(RectangleF rect) : base(rect)
        {
        }

        public SquareShape(SquareShape square) : base(square)
        {
        }
	}
}
