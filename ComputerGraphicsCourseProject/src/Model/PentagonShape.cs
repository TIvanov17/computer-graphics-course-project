using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.src.Model
{
    class PentagonShape : Shape
    {
		public PentagonShape(RectangleF rect) : base(rect)
		{
		}

		public PentagonShape(TriangleShape star) : base(star)
		{
		}


		public override bool Contains(PointF point)
		{

			return base.Contains(point);
		}

		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			PointF[] points = new PointF[5];

			int currentX = (int)Rectangle.X;
			int currentY = (int)Rectangle.Y;

			points[0] = new Point(currentX, currentY);
			points[1] = new Point(currentX - 25, currentY + 50);
			points[2] = new Point(currentX + 50, currentY + 100);
			points[3] = new Point(currentX + 100, currentY + 50);
			points[4] = new Point(currentX + 75, currentY + 0);

			// set opacity value to current fill color
			FillColor = Color.FromArgb(OpacityValue, FillColor);

			grfx.FillPolygon(
					new SolidBrush(FillColor),
					points
			);

			grfx.DrawPolygon(
					new Pen(StrokeColor, StrokeWidth),
					points
			);
		}
	}
}
