
using System;
using System.Drawing;

namespace Draw.src.Model
{
    class TriangleShape : Shape
    {
		private PointF[] points = new PointF[3];

		public TriangleShape(RectangleF rect) : base(rect)
		{
		}

		public TriangleShape(TriangleShape star) : base(star)
		{
		}


		public override bool Contains(PointF point)
		{

/*			float userClickX = point.X;
			float userClickY = point.Y;

			for(int index = 0; index < points.Length - 1; index++)
            {
				PointF currentPoint = points[index];
				PointF nextPoint = points[index + 1];

				double result = Math.Atan2(currentPoint.Y - point.Y, currentPoint.X - point.X) - 
					Math.Atan2(nextPoint.Y - point.Y, nextPoint.X - point.X);

			}
			*//*		float centerX = startRectangleX */
			return base.Contains(point);
		}

		public override void DrawSelf(Graphics grfx)
		{

			base.DrawSelf(grfx);

			

			int currentX = (int) Rectangle.X;
			int currentY = (int) Rectangle.Y;

			points[0] = new Point(currentX, currentY);
			points[1] = new Point(currentX + 50, currentY + 100);
			points[2] = new Point(currentX + 100, currentY + 0);

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
