using System;
using System.Drawing;

namespace Draw.src.Model
{
	[Serializable]
	class TriangleShape : Shape
    {
		private PointF[] points = new PointF[3];

		public TriangleShape(RectangleF rect) : base(rect)
		{
		}

		public TriangleShape(TriangleShape triangle) : base(triangle)
		{
		}


        public override bool Contains(PointF point)
		{
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

		public override object Clone()
		{
			return new TriangleShape(this);
		}

	}
}
